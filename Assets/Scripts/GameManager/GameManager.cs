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
using TMPro;

public enum GameState {Player1Turn, Player2Turn, BlueWin, RedWin}; 

public class GameManager : GenericSingleton<GameManager>
{
    //used to change state of game
    public GameState currentState;
    

    //Script References
    public Dice diceScript;
    public Player playerScript;

    //Text references
    public TextMeshProUGUI redWinsText;
    public TextMeshProUGUI blueWinsText;

    private void Start()
    {
        currentState = GameState.Player1Turn;
        redWinsText.gameObject.SetActive(false);
        blueWinsText.gameObject.SetActive(false);
    }

    //Game state code is immediately executed when when a new game state is called
    private void Update()
    {
        switch (currentState)
        {
            case GameState.Player1Turn:
                Debug.Log("GameState = Blue's Turn");
                break;

            case GameState.Player2Turn:
                Debug.Log("GameState = Red's Turn");
                break;

            case GameState.BlueWin:
                //UI Blue player wins
                blueWinsText.gameObject.SetActive(true);
                break;

            case GameState.RedWin:
                //UI Red player wins
                redWinsText.gameObject.SetActive(true);
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
