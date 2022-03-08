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

//Use to keep track of score, player/game states (rolling die, moving player)
public class GameManager : GenericSingleton<GameManager>
{
   //Restart game can be called to reload the entire game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
