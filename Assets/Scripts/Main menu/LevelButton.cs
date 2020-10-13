using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Sprite _starSprite;
    [SerializeField] private Image[] _levelStars= new Image[3];

    public void SetSpritesOfStars(int value)
    {
        for (int i = 0; i < value; i++)
            _levelStars[i].sprite = _starSprite;
    }
}
