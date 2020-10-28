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
    private float _elapsedTime = 0;
    private bool _isDead = false;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = 1;
    }

    private void AddHealth(float value)
    {
        if (!_rocket.IsDie)
            _healthBar.DOValue(_healthBar.value + value, _animationSpeed);
    }

    private void OnEnable()
    {
        _rocket.addHealth += AddHealth;
    }

    private void OnDisable()
    {
        _rocket.addHealth -= AddHealth;
    }

    public void CheckHealth()
    {
        if (_healthBar.value == 0)
        {
            _rocket.Die();
            _healthBar.DOKill();
            _healthBar.DOValue(1, _rocket.RespawnTime);
        }
    }
}
