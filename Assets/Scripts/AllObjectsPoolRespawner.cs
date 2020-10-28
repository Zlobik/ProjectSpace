using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllObjectsPoolRespawner : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;

    private BoxCollider2D[] _boxColliders;
    private SpriteRenderer[] _spriteRenderers;
    private Sprite[] _currentSprites;

    private float _time;
    private bool _isDead = true;

    private void Start()
    {
        _boxColliders = GetComponentsInChildren<BoxCollider2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _currentSprites = new Sprite[_spriteRenderers.Length];

        for (int i = 0; i < _spriteRenderers.Length; i++)
            _currentSprites[i] = _spriteRenderers[i].sprite;
    }

    private void EnableAllBoxColliders()
    {
        for (int i = 0; i < _boxColliders.Length; i++)
            _boxColliders[i].enabled = true;
    }

    private void FillAllSprites()
    {
        for (int i = 0; i < _spriteRenderers.Length; i++)
            _spriteRenderers[i].sprite = _currentSprites[i];
    }

    private void FixedUpdate()
    {
        if (_rocket.IsDie)
        {
            if (_isDead)
            {
                _isDead = false;
                EnableAllBoxColliders();
                FillAllSprites();
            }
            else if (!_isDead)
            {
                _time += Time.deltaTime;

                if (_time >= _rocket.RespawnTime + 3f)
                {
                    _time = 0;
                    _isDead = true;
                }
            }
        }
    }
}
