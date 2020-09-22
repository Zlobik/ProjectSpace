using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float _volume;

    public float Volume { get; private set; }

    private void Start()
    {
        Volume = _volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out RocketMover rocket))
        {
            Destroy(gameObject);
        }
    }
}
