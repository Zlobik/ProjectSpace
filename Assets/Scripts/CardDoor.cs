using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDoor : MonoBehaviour
{
    [SerializeField] private float _offsetDepthY;
    [SerializeField] private float _openningSpeed;
    [SerializeField] private bool _needBlueCard;
    [SerializeField] private bool _needGreenCard;
    [SerializeField] private bool _needRedCard;
    [SerializeField] private GameObject _dontHaveCardMessage;

    private float _time;
    private bool _isShowingMessage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RocketCards>())
        {
            RocketCards rocket = collision.GetComponent<RocketCards>();

            if (_needBlueCard)
            {
                if (rocket.BlueCard)
                    OpenDoor();
                else
                    ShowMessage();
            }
        }
    }

    private void OpenDoor()
    {
        transform.DOMoveY(transform.position.y + _offsetDepthY, _openningSpeed);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void ShowMessage()
    {
        _isShowingMessage = true;
        _time = 0;
        _dontHaveCardMessage.SetActive(true);
    }

    private void Update()
    {
        if (_isShowingMessage)
        { 
            _time += Time.deltaTime;

            if (_time >= 3.5f)
            {
                _dontHaveCardMessage.SetActive(false);
                _isShowingMessage = false;
            }
        }
    }
}
