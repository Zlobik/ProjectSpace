using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCounter;
    [SerializeField] private int _maxLevelStars;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _respawnTime;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _damage;
    [SerializeField] private float _speedWithoutDamage;
    [SerializeField] private float _animationSpeed;

    public bool IsDie;

    private int _starsCollected;
    private float _TimeLeft;
    private RocketMover _rocketMover;

    public int Coins;

    private void Start()
    {
        IsDie = false;
        _rocketMover = gameObject.GetComponent<RocketMover>();
        _TimeLeft = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            Coins++;
            _coinsCounter.text = Coins.ToString();
        }

        else if (collision.GetComponent<CheckPoint>())
            _spawnPoint = collision.transform;

        else if (collision.GetComponent<Thorns>())
            ChangeHealth(1);

        else if (collision.TryGetComponent(out RepairKit repairKit))
            ChangeHealth(-repairKit.Volume);

        else if (collision.GetComponent<Star>())
            _starsCollected++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Texture>() && _rocketMover.SpeedOfTheObject * _damage > _speedWithoutDamage)
            ChangeHealth(_damage * _rocketMover.SpeedOfTheObject);

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            ChangeHealth(enemy.Damage);
    }

    private void Die()
    {
        _rocketMover.Refuel(1 -_rocketMover.GetFuelValue());
        ChangeHealth(-1);

        transform.position = _spawnPoint.position;
        transform.DORotate(new Vector3(0,0,0), 0.001f);

        _TimeLeft = 0;
        IsDie = false;
    }

    private void Update()
    {
        if (IsDie)
        {
            _TimeLeft += Time.deltaTime;

            if (_respawnTime <= _TimeLeft)
                Die();
        }
    }

    private void ChangeHealth(float value)
    {
        _healthBar.DOValue(_healthBar.value - value, _animationSpeed);
    }

    public float GetHealthBarValue()
    {
        float value = _healthBar.value;
        return value;
    }
}
