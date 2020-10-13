using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCollector : MonoBehaviour
{
    public int StarsCollected { get; private set; }

    private void Start()
    {
        StarsCollected = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LevelStar>())
            StarsCollected++;
    }
}
