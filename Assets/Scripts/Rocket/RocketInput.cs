using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RocketMover), typeof(Animator))]
public class RocketInput : MonoBehaviour
{
    private RocketMover _mover;
    private Rocket _rocket;
    private BurningRocketFuel _burnFuel;
    private Animator _animator;

    private void Start()
    {
        _mover = GetComponent<RocketMover>();
        _burnFuel = GetComponent<BurningRocketFuel>();
        _rocket = GetComponent<Rocket>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_rocket.IsDie)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _mover.MoveUp();
                _burnFuel.MoveUpConsuption();
            }
            if (Input.GetKey(KeyCode.S))
            {
                _mover.MoveDown();
                _burnFuel.MoveDownConsuption();
            }
            if (Input.GetKey(KeyCode.A))
                _mover.RotateLeft();
            if (Input.GetKey(KeyCode.D))
                _mover.RotateRight();
            else
                _burnFuel.IdleConsuption();

            if (Input.GetKeyUp(KeyCode.W))
                _animator.SetBool("IsPressedUpButton", false);
            if (Input.GetKeyDown(KeyCode.W))
                _animator.SetBool("IsPressedUpButton", true);
            if (_rocket.IsDie)
            {
                _animator.SetBool("IsDead", true);
            }
        }
    }
}
