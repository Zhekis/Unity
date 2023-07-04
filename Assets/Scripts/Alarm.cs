using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volumeMin = 0f;
    private float _volumeMax = 1f;
    private float _volumeScale;
    private float _runningTime = 0;
    private Coroutine _volumeChanger;
    private float speed = 5f;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volumeMin;
    }

    public void VolumeUp()
    {
        _audioSource.Play();

        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        _volumeChanger = StartCoroutine(ChangeVolume(_audioSource.volume, _volumeMax, _runningTime));
    }

    public void VolumeDown()
    {
        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        _volumeChanger = StartCoroutine(ChangeVolume(_audioSource.volume, _volumeMin, _runningTime));
    }

    private IEnumerator ChangeVolume(float currentVolume, float targetVolume, float runningTime)
    {
        while (_audioSource.volume != targetVolume)
        {
            runningTime += Time.deltaTime;
            _volumeScale = runningTime / speed;
            _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, _volumeScale);
            yield return null;
        }
    }
}
