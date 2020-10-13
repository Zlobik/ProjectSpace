using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            Destroy(gameObject);
            _cardImage.SetActive(true);
        }
    }
}
