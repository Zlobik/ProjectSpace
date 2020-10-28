using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Animator))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private Vector3 _firstRespawnPoint;
    [SerializeField] private float _timeBeforeRespawn;
    [SerializeField] private FuelBar _fuelBar;

    private float _time = 0;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private Vector3 _checkPoint;
    private bool _isFreezePosition = false;
    private bool _timer = false;


    public event UnityAction<float> addHealth;

    public float RespawnTime => _timeBeforeRespawn;
    public int StarsCollected { get; private set; }
    public bool IsDie { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _checkPoint = _firstRespawnPoint;
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CheckPoint>())
            _checkPoint = collision.gameObject.transform.position;
        if (collision.GetComponent<LevelStar>())
            StarsCollected++;
    }

    public void TakeDamage(float damage)
    {
        addHealth?.Invoke(-damage);
    }

    public void Die()
    {
        IsDie = true;
        _timer = true;
        _isFreezePosition = true;

        _animator.SetBool("IsDead", _timer);
        _animator.SetBool("IsPressedUpButton", false);
    }

    private void FreezePosition()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void UnFreeze()
    {
        _rigidBody.constraints = RigidbodyConstraints2D.None;
        _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Respawn()
    {
        IsDie = false;
        UnFreeze();
        transform.rotation = Quaternion.identity;
        transform.position = _checkPoint;
        _animator.SetBool("IsDead", false);
    }

    private void Update()
    {
        if (_timer)
        {
            _time += Time.deltaTime;

            if(_time >= _timeBeforeRespawn / 2)
            {
                if (_isFreezePosition)
                {
                    FreezePosition();
                    _isFreezePosition = false;
                }
                if(_time >= _timeBeforeRespawn)
                {
                    Respawn();
                    _time = 0;
                    _timer = false;
                }
            }
        }
    }

    public void OutOfFuel()
    {
        _boxCollider.enabled = false;

        _animator.SetBool("IsPressedUpButton", false);
        _isFreezePosition = true;
    }

    public void AddHealth(float value)
    {
        addHealth?.Invoke(value);
    }

    public void AddFuel(float value)
    {
        _fuelBar.AddFuel(value);
    }
}
