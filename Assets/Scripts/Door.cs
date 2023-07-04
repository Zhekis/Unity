using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volumeMin = 0f;
    private float _volumeMax = 1f;
    private float _volumeScale;
    private float _runningTime = 0;
    public float speed = 0.5f;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _exitColor;
    [SerializeField] private UnityEvent _reached;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volumeMin;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopAllCoroutines();
            var changeVolume = StartCoroutine(ChangeVolume(_audioSource.volume, _volumeMax, _runningTime));
            _reached?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == false)
        {
            StopAllCoroutines();
            _renderer.color = _exitColor;
            var changeVolume = StartCoroutine(ChangeVolume(_audioSource.volume, _volumeMin, _runningTime));
        }
    }
}
