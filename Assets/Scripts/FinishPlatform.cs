using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private GameObject _nextLevelPanel;
    [SerializeField] private Image[] _stars = new Image[3];
    [SerializeField] private Sprite _fullStarSprite;
    [SerializeField] private Transform _levelStars;
    [SerializeField] private StarsCollector _starsCollector;

    private int _starsOnLevel;
    private int _playerCollectedStars;

    private void Start()
    {
        _starsOnLevel = _levelStars.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rocket>())
        {
            Time.timeScale = 0;
            _playerCollectedStars = _starsCollector.StarsCollected;

            int value = 0;

            if (_playerCollectedStars > 0)
            {
                if (_playerCollectedStars == _starsOnLevel)
                    value = 3;
                else if (_playerCollectedStars >= _starsOnLevel / 2)
                    value = 2;
                else if (_playerCollectedStars < _starsOnLevel / 2 && _playerCollectedStars > _starsOnLevel / 5)
                    value = 1;
            }
            else
                value = 0;

            ChangeEmptyStarsToFull(value);
            UnlockNextLevel();
        }
    }

    private void ChangeEmptyStarsToFull(int value)
    {
        for (int i = 0; i < value; i++)
            _stars[i].sprite = _fullStarSprite;

        _nextLevelPanel.SetActive(true);

        PlayerPrefs.SetInt(_sceneName, value);
    }

    private void UnlockNextLevel()
    {
        PlayerPrefs.SetInt(_nextSceneName, 0);
    }
}
