using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _enterColor;
    [SerializeField] private Color _exitColor;
    [SerializeField] private UnityEvent _reachedEnter;
    [SerializeField] private UnityEvent _reachedExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.color = _enterColor;
            _reachedEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) == false)
        {
            _renderer.color = _exitColor;
            _reachedExit?.Invoke();
        }
    }
}
