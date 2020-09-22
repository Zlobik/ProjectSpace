using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _upForce;
    [SerializeField] private float _animationSpeed;

    [SerializeField] private Slider _fuelBar;
    [SerializeField] private float _idleConsuption;
    [SerializeField] private float _upConsuption;
    [SerializeField] private GameObject _rocketBottom;

    private bool _isRefueled = false;
    private float _timePassed;
    private Rocket _rocket;

    public float SpeedOfTheObject { get; private set; }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rocket = GetComponent<Rocket>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fuel fuel))
        {
            _isRefueled = true;
            Refuel(fuel.Volume);
        }
    }

    private void BurnFuel(float consuption)
    {
        if (consuption > 0 && !_isRefueled)
            _fuelBar.DOValue(_fuelBar.value - consuption, 0.3f);
    }

    public void Refuel(float fuelVolume)
    {
        _fuelBar.DOValue(_fuelBar.value + fuelVolume, _animationSpeed);

        _isRefueled = false;
    }

    public float GetFuelValue()
    {
        return _fuelBar.value;
    }

    private void Update()
    {
        SpeedOfTheObject = _rigidBody.velocity.magnitude * Time.deltaTime;

        if (_isRefueled)
        {
            _timePassed += Time.deltaTime;

            if (_timePassed >= _animationSpeed)
            {
                _timePassed = 0;
                _isRefueled = false;
            }
        }

        if (_fuelBar.value != 0 && _rocket.GetHealthBarValue() != 0 && !_rocket.IsDie)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _rigidBody.AddForce(transform.up * _upForce * Time.deltaTime);

                BurnFuel(_upConsuption * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
                _rigidBody.AddForce((transform.up * -_upForce * Time.deltaTime) * 0.3f, ForceMode2D.Force);

            if (Input.GetKey(KeyCode.A))
                _rigidBody.rotation += _rotationSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.D))
                _rigidBody.rotation -= _rotationSpeed * Time.deltaTime;

            else
                BurnFuel(_idleConsuption * Time.deltaTime);
        }
        else
            _rocket.IsDie = true;
    }
}
