using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Assets;//importing namespace of generic singleton
using UnityEngine.SceneManagement;

//Use to keep track of score, player/game states (rolling die, moving player)
public class GameManager : GenericSingleton<GameManager>
{
   //method to restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
