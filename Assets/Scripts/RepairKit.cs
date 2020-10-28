using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private float _capacity;

    private SpriteRenderer _render;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rocket>(out Rocket rocket))
        {
            rocket.AddHealth(_capacity);
            _render.sprite = null;
            _boxCollider.enabled = false;
        }
    }
}
