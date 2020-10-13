using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningRocketFuel : MonoBehaviour
{
    [SerializeField] private Slider _fuelBar;
    [SerializeField] private float _consuption;
    [SerializeField] private float _idleConsuption;

    private Rocket _rocket;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
        CheckFuel();
    }

    public void MoveUpConsuption()
    {
        _fuelBar.value -= _consuption * Time.deltaTime;
        CheckFuel();
    }

    public void MoveDownConsuption()
    {
        _fuelBar.value -= _consuption / 3 * Time.deltaTime;
        CheckFuel();
    }

    public void IdleConsuption()
    {
        _fuelBar.value -= _idleConsuption * Time.deltaTime;
        CheckFuel();
    }

    private void CheckFuel()
    {
        if (_fuelBar.value == 0)
        {
            _rocket.OutOfFuel();
        }
    }
}
