using Cysharp.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Scene _currentScene;

    [SerializeField]
    private float _waitBeforeTransit = 1f;

    [SerializeField]
    private Animator _sceneTransitionAnimatorController;

    [SerializeField]
    private GeneralEvent _sceneLoadedEvent;

    private void Awake()
    {
        _currentScene = SceneManager.GetActiveScene();
        Debug.Log($"Current scene: {_currentScene.name}");
    }

    public void ReloadScene()
    {
        TransitToScene(_currentScene.name);
    }

    public void TransitToScene(string newSceneName)
    {
        StartCoroutine(TransitToSceneRoutine(newSceneName));
    }

    public IEnumerator TransitToSceneRoutine(string newSceneName)
    {
        Debug.Log($"Transit to scene: {newSceneName}");
        if (SceneManager.sceneCount > 1)
        {
            StartCoroutine(UnloadScene(_currentScene.name));
        }
        Debug.Log("Start scene transition");
        _sceneTransitionAnimatorController.SetTrigger("EndScene");
        Debug.Log("End scene transition");
        Debug.Log("Wait before transit");
        yield return new WaitForSeconds(_waitBeforeTransit);
        Debug.Log("Start loading scene");
        StartCoroutine(LoadScene(newSceneName));
    }

    /// <summary>
    /// Used to call from animator so I can set time to 1 in game manager
    /// </summary>
    public void SceneLoaded()
    {
        if (_sceneLoadedEvent is not null)
        {
            _sceneLoadedEvent.Raise();
        }
    }


    private IEnumerator UnloadScene(string currentSceneName)
    {
        Debug.Log($"Unload scene: {currentSceneName}");
        AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(currentSceneName);
        //run hide anim
        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator LoadScene(string newSceneName)
    {
        Debug.Log($"Load scene: {newSceneName}");
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(newSceneName);
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            if (asyncOp.progress >= 0.9f)
            {
                asyncOp.allowSceneActivation = true;
                Debug.Log("Scene loaded");
            }

            yield return null;
        }

        _currentScene = SceneManager.GetSceneByName(newSceneName);
    }
}