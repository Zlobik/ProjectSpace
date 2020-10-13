using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private float _animationSpeed;

    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = 1;
    }

    private void ChangeHealth(float value)
    {
        if (_healthBar.value - value <= 0)
            _rocket.Die();

        _healthBar.DOValue(_healthBar.value - value, _animationSpeed);
    }

    private void OnEnable()
    {
        _rocket.ChangeHealth += ChangeHealth;
    }

    private void OnDisable()
    {
        _rocket.ChangeHealth -= ChangeHealth;
    }
}
