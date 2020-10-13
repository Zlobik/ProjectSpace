using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private float _closingDoorSpeed;
    [SerializeField] private float _openningDoorSpeed;
    [SerializeField] private float _closeDoorOffsetX;
    [SerializeField] private float _timeBeforeDoorClosed;
    [SerializeField] private float _pressingDepth;

    private Vector3 _currentPlatePosition;
    private Vector3 _closedDoorPosition;
    private float _time;
    private bool _isExitPlate;
    private bool _isOnPlate = false;

    private void Start()
    {
        _currentPlatePosition = transform.position;
        _closedDoorPosition = new Vector3(_door.position.x , _door.position.y, _door.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            transform.DOMoveY(_currentPlatePosition.y - _pressingDepth, 0.3f);
            _isOnPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            _isOnPlate = false;
            _isExitPlate = true;

            transform.DOMoveY(_currentPlatePosition.y, 0.5f);
        }
    }
    private void CloseDoor()
    {
        _door.DOMoveX(_closedDoorPosition.x, _closingDoorSpeed);
    }

    private void Update()
    {
        if (_isExitPlate)
        {
            _time += Time.deltaTime;

            if(_time >= _timeBeforeDoorClosed)
            {
                CloseDoor();
                _time = 0;
                _isExitPlate = false;
            }
        }
        if (_isOnPlate)
        {
            _door.position = Vector3.MoveTowards(_door.position, new Vector3(_closedDoorPosition.x - _closeDoorOffsetX, _closedDoorPosition.y), _openningDoorSpeed * Time.deltaTime);

            if (transform.position.x == _closedDoorPosition.x - _closeDoorOffsetX)
                _isOnPlate = false;
        }
    }
}
