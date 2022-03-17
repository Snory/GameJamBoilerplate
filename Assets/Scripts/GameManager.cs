using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { GAMEPLAY, PAUSED, MAINMENU }

public class GameManager : Singleton<GameManager>
{

    private GameState _gamestate;

    public GameState GameState { get => _gamestate; }

    /*
     Mus� handlovat stavy b�hu hry:
        - pause
        - running

     Asi by m�l v�d�t, kde se nach�z�m?
        - main menu
        - paused game
        - game

     Mus� reagovat na z�kladn� vlastnosti hry:
        - zapauzovat hru
        - zobrazit takov� to in game menu
        - p�ej�t do hlavn�ho menu
        - p�epnout sc�nu by teda asi m�l um�t


     Main menu - paused state - new scene
     Paused menu - paused state
    
     Cht�l bych zavolat p�i na�ten� levelu level mana�era, kter� se postar� o na�ten� v�ech propriet pro dan� level
        - vyresetovat hodnoty
        - naspawnovat objekty 
        - naspawnovat p��padn� mana�ery pro dan� level
     */


    public void TransitToState(GameState newGameState)
    {
        _gamestate = newGameState;
    }

    public IEnumerator TransitToScene(string newSceneName, LoadSceneMode loadMode)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetSceneByName(newSceneName).buildIndex, loadMode);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
   
}
