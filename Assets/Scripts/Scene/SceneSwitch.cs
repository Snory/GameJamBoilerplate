using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField]
    private string _currentScene;

    [SerializeField]
    private EventSystem _eventSystemInScene;

    [SerializeField]
    private AudioListener _audioListenerInScene;

    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().name;
    }


    public void SwitchScene(string NextSceneName)
    {
        if (_eventSystemInScene != null)
        {
            _eventSystemInScene.enabled = false;
        }

        if (_audioListenerInScene != null)
        {
            _audioListenerInScene.enabled = false;
        }

        _sceneTransition.TransitToScene(_currentScene, NextSceneName);
    }

    public void ReloadScene()
    {
        _sceneTransition.TransitToScene(_currentScene, _currentScene);
    }

}
