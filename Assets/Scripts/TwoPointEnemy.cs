using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointEnemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _firstPointSpeed;
    [SerializeField] private float _secondPointSpeed;
    [SerializeField] private Transform _path;

    private SpriteRenderer _render;
    private Vector3[] _points;
    
    public float Damage => _damage;

    private void Start()
    {
        _render = GetComponent<SpriteRenderer>();
        _points = new Vector3[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i).position;

        transform.position = _points[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Rocket>(out Rocket rocket))
            rocket.TakeDamage(_damage);
    }

    private void MoveToFirstPoint()
    {
        transform.DOMoveX(_points[0].x, _firstPointSpeed);
        _render.flipX = true;
    }

    private void MoveToSecondPoint()
    {
        transform.DOMoveX(_points[1].x, _secondPointSpeed, false);
        _render.flipX = false;
    }

    private void Update()
    {
        if (transform.position.x == _points[0].x)
            MoveToSecondPoint();
        if (transform.position.x == _points[1].x)
            MoveToFirstPoint();
    }
}
