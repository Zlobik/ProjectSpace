using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _upSpeed;
    [SerializeField] private float _rotateSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveUp()
    {
        _rigidbody.AddForce(transform.up * _upSpeed * Time.deltaTime, ForceMode2D.Force);
    }

    public void MoveDown()
    {
        _rigidbody.AddForce(transform.up * -(_upSpeed / 3) * Time.deltaTime, ForceMode2D.Force);
    }

    public void RotateRight()
    {
        _rigidbody.rotation -= _rotateSpeed * Time.deltaTime;
    }

    public void RotateLeft()
    {
        _rigidbody.rotation += _rotateSpeed * Time.deltaTime;
    }
}
