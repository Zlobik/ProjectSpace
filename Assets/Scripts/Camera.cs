using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smooth;

    private Vector3 _offset = new Vector3(0, 0, -10);

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position + _offset, _smooth * Time.deltaTime);
    }
}
