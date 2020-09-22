using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRocketCoins : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private int _coins;

    private void Start()
    {
        _coins = _player.GetComponent<Rocket>().Coins;
    }
}
