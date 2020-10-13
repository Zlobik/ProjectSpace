using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class FuelBar : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    [SerializeField] private Rocket _rocket;

    private Slider _fuelBar;

    private void Start()
    {
        _fuelBar = GetComponent<Slider>();
    }

    public void Refuel(float value)
    {
        _fuelBar.DOValue(_fuelBar.value + value, _animationSpeed);
    }
}
