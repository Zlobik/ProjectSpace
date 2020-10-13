using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanister : MonoBehaviour
{
    [SerializeField] private float _capacity;

    private SpriteRenderer _render;
    private BoxCollider2D _boxCollider;

    public float Capacity => _capacity;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            _render.sprite = null;
            _boxCollider.enabled = false;
        }
    }
}
