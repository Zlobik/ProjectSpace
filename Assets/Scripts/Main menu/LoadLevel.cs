using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public string SceneName => _sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1;
    }
}
