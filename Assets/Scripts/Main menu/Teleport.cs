using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _teleportationPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = _teleportationPoint.position;
    }
}
