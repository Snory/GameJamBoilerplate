using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string NextScene;
    public BoolVariable Additive;

    [SerializeField]
    private SceneTransitionBase _sceneTransition;

    public void SwitchScene()
    {
        _sceneTransition.TransitToScene(SceneManager.GetActiveScene().name, NextScene, Additive.Value);
    }
}
