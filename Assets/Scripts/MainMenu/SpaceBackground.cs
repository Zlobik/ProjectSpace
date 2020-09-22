using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceBackground : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    [SerializeField] private Transform[] _points;

    private int count = 0;

    private void Start()
    {
        transform.DOScale(1.5f, _animationSpeed).SetLoops(-1, LoopType.Yoyo);

        while (true)
        {
            transform.DOMove(_points[count].position, _animationSpeed);
            count++;

            if (count == _points.Length)
                count = 0;
        }

    }
}
