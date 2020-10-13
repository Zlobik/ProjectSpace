using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Rocket _rocket;
    private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(0, 0, -10);
        _rocket = _target.GetComponent<Rocket>();
    }

    private void Update()
    {
        if (!_rocket.IsDie)
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, 100000 * Time.deltaTime);
    }
}
