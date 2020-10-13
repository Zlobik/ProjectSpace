using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private bool _isUnlock = false;

    private LoadLevel _loadLevel;
    private LevelButton _levelButton;
    private CanvasGroup _canvasGroup;
    private string _currentLevelName;

    private void Start()
    {
        _loadLevel = GetComponent<LoadLevel>();
        _levelButton = GetComponent<LevelButton>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _currentLevelName = _loadLevel.SceneName;

        if (!_isUnlock)
            if (PlayerPrefs.HasKey(_currentLevelName))
            {
                _isUnlock = true;
                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
            }
        if (_isUnlock)
        {

            if (PlayerPrefs.GetInt(_currentLevelName) >= PlayerPrefs.GetInt($"previous {_currentLevelName}") || !PlayerPrefs.HasKey($"previous {_currentLevelName}"))
            {
                _levelButton.SetSpritesOfStars(PlayerPrefs.GetInt(_currentLevelName));
                PlayerPrefs.SetInt($"previous {_currentLevelName}", PlayerPrefs.GetInt(_currentLevelName));
            }
            else
                _levelButton.SetSpritesOfStars(PlayerPrefs.GetInt($"previous {_currentLevelName}"));
        }
    }
}
