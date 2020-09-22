using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] private Transform _transformPoint;
    [SerializeField] private float _speed;

    private Transform _currentPosition;
    private bool _isOnPosition = false;

    private void Start()
    {
        _currentPosition.position = transform.position;
    }

    private void Update()
    {
        if (!_isOnPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _transformPoint.position, _speed * Time.deltaTime);

            if (transform.position == _transformPoint.position)
                _isOnPosition = true;
        }

        if (_isOnPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPosition.position, _speed * Time.deltaTime);

            if (transform.position == _transformPoint.position)
                _isOnPosition = false;
        }
    }
}
