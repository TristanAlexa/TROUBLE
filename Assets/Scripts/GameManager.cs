/**
    @file: GameManager.cs
    Tracking game states and player states. Prints U.I.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Assets;
using UnityEngine.SceneManagement;


public class GameManager : GenericSingleton<GameManager>
{
    /**
     * public enum GameState {
     *  Roll = 0,
     *  Move = 1,
     *  Win = 3;
     *  }
    */


   //Restart game can be called to reload the entire game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
