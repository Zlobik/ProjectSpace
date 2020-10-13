using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRocket : MonoBehaviour
{
    [SerializeField] private string _rocketName;

    public void SaveChoosedRocket()
    {
        PlayerPrefs.SetString("ChoosedRocket", _rocketName);
    }
}
