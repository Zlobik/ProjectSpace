using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonsPool : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Transform[] _doors;

    private SpriteRenderer[] _greenLightSprites;
    private CircleCollider2D[] _circleColliders;
    private Vector3[] _doorsClosedPosition;
    private bool _isDisableAllGreenLights = true;
    private float _time;

    private void Start()
    {
        _greenLightSprites = GetComponentsInChildren<SpriteRenderer>();
        _circleColliders = GetComponentsInChildren<CircleCollider2D>();
        _doorsClosedPosition = new Vector3[_doors.Length];

        for (int i = 0; i < _doors.Length; i++)
            _doorsClosedPosition[i] = _doors[i].position;
    }

    private void EnableAllGreenLights()
    {
        for (int i = 0; i < _greenLightSprites.Length; i++)
            if (_greenLightSprites[i].TryGetComponent<GreenLight>(out GreenLight greenLight))
                _greenLightSprites[i].enabled = false;
    }

    private void EnableAllCircleColliders()
    {
        for (int i = 0; i < _circleColliders.Length; i++)
            _circleColliders[i].enabled = true;
    }

    private void CloseAllDoors()
    {
        for (int i = 0; i < _doors.Length; i++)
            _doors[i].position = _doorsClosedPosition[i];
    }

    private void FixedUpdate()
    {
        if (_rocket.IsDie || _rocket.EmptyFuel)
        {
            if (_isDisableAllGreenLights)
            {
                EnableAllGreenLights();
                EnableAllCircleColliders();
                CloseAllDoors();
                _isDisableAllGreenLights = false;
            }
        }
        if (!_isDisableAllGreenLights)
        {
            _time += Time.deltaTime;

            if (_time >= _rocket.RespawnTime + 3f)
            {
                _isDisableAllGreenLights = true;
                _time = 0;
            }
        }
    }
}
