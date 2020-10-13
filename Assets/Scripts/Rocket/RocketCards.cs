using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCards : MonoBehaviour
{
    public bool BlueCard { get; private set; }

    private void Start()
    {
        BlueCard = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlueCard>())
            BlueCard = true;
    }
}
