using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private float _offsetDoorX;
    [SerializeField] private SpriteRenderer _greenLight;

    private Vector3 _closedDoorPosition;
    private CircleCollider2D _circleCollider;

    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _closedDoorPosition = _door.position;
        _greenLight.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            _greenLight.enabled = true;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _door.DOMoveX(_door.position.x + _offsetDoorX, 3.5f);
        _circleCollider.enabled = false;
    }
}
