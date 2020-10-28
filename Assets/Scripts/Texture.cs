using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _collisionForceWithoutDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket))
        {
            float collisionForce = collision.relativeVelocity.magnitude;

            if (collisionForce > _collisionForceWithoutDamage)
                rocket.TakeDamage(collisionForce * _damage);
        }
    }
}
