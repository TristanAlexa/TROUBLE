/**
    @file: GameManager.cs
    Tracking game states and player states.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Assets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Roll, Move, Win}; 

public class GameManager : GenericSingleton<GameManager>
{
    //used to change state of game
    public GameState currentState;

    //Script References
    public Dice diceScript;
    public Player playerScript;

    private void Start()
    {
        currentState = GameState.Roll;
    }

    //Game state code is immediately executed when when a new game state is called
    private void Update()
    {
        switch (currentState)
        {
            case GameState.Roll:
                Debug.Log("GameState = Roll");
                break;

            case GameState.Move:
                Debug.Log("GameState = Move");    
                diceScript.Reset();
                break;

            default:
                Debug.LogError("Game is an invalid state!");
                return;
        }   
    }

    //Restart game can be called to reload the entire game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
