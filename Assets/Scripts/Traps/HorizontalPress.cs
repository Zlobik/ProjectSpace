using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPress : MonoBehaviour
{
    [SerializeField] private float _offsetDepthX;
    [SerializeField] private float _goBackSpeed;
    [SerializeField] private float _compressSpeed;
    [SerializeField] private bool _isNegativeX;

    private Vector3 _currentPosition;
    private bool _isCompress = true;
    private float _time;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    private void MoveBack()
    {
        transform.DOMoveX(_currentPosition.x, _goBackSpeed);
    }

    private void Update()
    {
        if (_isCompress)
        {
            if (!_isNegativeX)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentPosition.x + _offsetDepthX, _currentPosition.y, _currentPosition.z), _compressSpeed * Time.deltaTime);

                if (transform.position.x >= _currentPosition.x + _offsetDepthX)
                {
                    _isCompress = false;
                    MoveBack();
                }
            }
            else if (_isNegativeX)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(_currentPosition.x - _offsetDepthX, _currentPosition.y, _currentPosition.z), _compressSpeed * Time.deltaTime);

                if(transform.position.x <= _currentPosition.x - _offsetDepthX)
                {
                    _isCompress = false;
                    MoveBack();
                }
            }
        }
        else if (!_isCompress)
        {
            _time += Time.deltaTime;

            if (_time >= _goBackSpeed)
            {
                _isCompress = true;
                _time = 0;
            }
        }
    }
}
