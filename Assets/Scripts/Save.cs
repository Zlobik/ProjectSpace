using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void SaveStarsForLevel(string SceneName, int starsReceived)
    {
        PlayerPrefs.SetInt("Level1", 2);
    }
}
