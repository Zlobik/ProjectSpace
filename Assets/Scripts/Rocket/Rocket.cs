using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float _timeBeforeRespawn;
    [SerializeField] private Vector3 _firstRespawnPoint;
    [SerializeField] private float _damage;
    [SerializeField] private float _collisionForceWithoutDamage;
    [SerializeField] private FuelBar _fuelBar;
    [SerializeField] private int _health;

    private float _time;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Vector3 _respawnPoint;

    public event UnityAction<float> ChangeHealth;
    public event UnityAction<int> SubtractHealth;

    public float RespawnTime => _timeBeforeRespawn;
    public int Health {get; private set;}
    public bool IsDie { get; private set; }
    public bool EmptyFuel { get; private set; }
    public int StarsCollected { get; private set; }

    private void Awake()
    {
        Health = _health;
    }

    private void Start()
    {
        IsDie = false;
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _respawnPoint = _firstRespawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Texture>())
        {
            float collisionForce = collision.relativeVelocity.magnitude;

            if(collisionForce > _collisionForceWithoutDamage)
                ChangeHealth?.Invoke(collisionForce * _damage);
        }

        if (collision.gameObject.GetComponent<Enemy>())
        {
            float damage = collision.gameObject.GetComponent<Enemy>().Damage;
            ChangeHealth?.Invoke(damage);
        }
        if (collision.gameObject.GetComponent<TwoPointEnemy>())
            ChangeHealth?.Invoke(collision.gameObject.GetComponent<TwoPointEnemy>().Damage);

        if (collision.gameObject.GetComponent<Thorns>())
            ChangeHealth?.Invoke(1);
        if (collision.gameObject.GetComponent<VerticalPress>() || collision.gameObject.GetComponent<HorizontalPress>())
            ChangeHealth?.Invoke(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RepairKit>())
        {
            float health = collision.GetComponent<RepairKit>().Health;

            ChangeHealth?.Invoke(-health);
        }
        if (collision.GetComponent<FuelCanister>())
        {
            float capacity = collision.GetComponent<FuelCanister>().Capacity;

            _fuelBar.Refuel(capacity);
        }
        if (collision.GetComponent<CheckPoint>())
            _respawnPoint = collision.gameObject.transform.position;
        if (collision.GetComponent<LevelStar>())
            StarsCollected++;
    }


    public void Die()
    {
        _time = 0;
        IsDie = true;

        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

        _animator.SetBool("IsDead", IsDie);
        _animator.SetBool("IsPressedUpButton", false);
    }

    public void OutOfFuel()
    {
        EmptyFuel = true;
        _time = 0;

        _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

        _animator.SetBool("IsPressedUpButton", false);
    }

    private void Update()
    {
        if (IsDie || EmptyFuel)
        {
            _time += Time.deltaTime;

            if(_time >= _timeBeforeRespawn)
            {
                Health--;
                SubtractHealth?.Invoke(Health);

                if (Health == 0)
                {
                    _respawnPoint = _firstRespawnPoint;
                    Health = _health;
                    SubtractHealth?.Invoke(Health);
                }
                _rigidBody.constraints = RigidbodyConstraints2D.None;
                _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                transform.position = _respawnPoint;
                transform.rotation = Quaternion.identity;

                _fuelBar.Refuel(1);
                ChangeHealth?.Invoke(-1);

                EmptyFuel = false;
                IsDie = false;
                _animator.SetBool("IsDead", IsDie);
            }
        }
    }
}
