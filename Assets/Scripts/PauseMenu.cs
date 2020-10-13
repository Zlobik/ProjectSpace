using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnClick()
    {
        Time.timeScale = 0;
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
    }
}
