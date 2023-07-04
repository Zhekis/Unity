using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVolume : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volumeMin = 0f;
    private float _volumeMax = 1f;
    private float _currentVolume;
    private float _targetVolume;
    [SerializeField] private float _duration;
    private float _volumeScale;
    private float _runningTime;

    public void ChangeVolume()
    {
        var changeVolume = StartCoroutine(ChangeVolume(_volumeMin, _volumeMax));
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volumeMin;
        ChangeVolume();
    }

    private IEnumerator ChangeVolume(float currentVolume, float targetVolume)
    {

        _currentVolume = _volumeMin;
        _targetVolume = _volumeMax;

        while (_audioSource.volume != _targetVolume)
        {
            _runningTime += Time.deltaTime;
            _volumeScale = _runningTime / _duration;
            _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume, _volumeScale);
            yield return null;
        }
    }
}
