using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private HealthDisplay _healthDisplay;

    private Rocket _rocket;
    private SpriteRenderer _render;
    private CircleCollider2D _circleCollider;
    private Sprite _currentSprite;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _currentSprite = _render.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            _rocket = collision.GetComponent<Rocket>();
            _render.sprite = null;
            _circleCollider.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (Convert.ToInt32(_healthDisplay.Text) == 0)
        {
            _render.sprite = _currentSprite;
            _circleCollider.enabled = true;
        }
    }
}
