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
    public TextMeshProUGUI redTurnText;
    public TextMeshProUGUI blueTurnText;

    //Set initial gamestate and button visibility
    public override void Awake()
    {
        currentState = GameState.Player1Turn;
        redWinsText.gameObject.SetActive(false);
        blueWinsText.gameObject.SetActive(false);
        redTurnText.gameObject.SetActive(false);
        blueTurnText.gameObject.SetActive(false);
    }

    //Game state code is immediately executed when when a new game state is called
    private void Update()
    {
        switch (currentState)
        {
            case GameState.Player1Turn:
                //State player turn using UI
                blueTurnText.gameObject.SetActive(true);
                redTurnText.gameObject.SetActive(false);
                break;

            case GameState.Player2Turn:
                //state player turn using UI
                redTurnText.gameObject.SetActive(true);
                blueTurnText.gameObject.SetActive(false);

                break;

            case GameState.BlueWin:
                //UI Blue player wins
                if (blueWinsText != null)
                {
                    blueWinsText.gameObject.SetActive(true);

                }
                if (blueTurnText != null)
                {
                    Destroy(blueTurnText);
                }
                break;

            case GameState.RedWin:
                //UI Red player wins
                if (redWinsText != null)
                {
                    redWinsText.gameObject.SetActive(true);
                }

                if (redTurnText != null)
                {
                    Destroy(redTurnText);
                }
                break;

                default:
                Debug.LogError("Game is an invalid state!");
                return;
        }   
    }
}
