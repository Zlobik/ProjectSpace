using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomBackground : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _backgrounds;
    [SerializeField] private Sprite[] _backgroundSprites;

    private void Awake()
    {
        _backgrounds[0].sprite = _backgroundSprites[Random.Range(0, _backgroundSprites.Length)];
        _backgrounds[1].sprite = _backgrounds[0].sprite;
    }
}
