using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _currentPoint = 0;
    public float Damage { get; private set; }

    private void Start()
    {
        Damage = _damage;
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);

        if (transform.position == _points[_currentPoint].position)
        {
            _currentPoint++;
            _renderer.flipX = !_renderer.flipX;
        }

        if (_currentPoint == _points.Length)
            _currentPoint = 0;
    }
}
