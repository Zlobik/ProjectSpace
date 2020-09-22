using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    [SerializeField] private Rigidbody2D _playersRigidBody;

    private bool _isPressed;

    private void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(_isPressed = false);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _isPressed = true;
    }

    private void Update()
    {
        if (_isPressed)
            _playersRigidBody.AddForce(transform.up * 500 * Time.deltaTime);
    }
}
