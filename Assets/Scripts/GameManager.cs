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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Roll, Move, Win}; //

public class GameManager : GenericSingleton<GameManager>
{
    //used to change state of game
    public GameState currentState;

    //Canvas and button references
    public CanvasGroup buttonCanvas;
    public Dice diceScript;

    private void Start()
    {
        //Find the canvases on the UI GameObject
        buttonCanvas = GameObject.FindGameObjectWithTag("ButtonCanvas").GetComponent<CanvasGroup>();

        currentState = GameState.Roll;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.Roll:
                Debug.Log("GameState = Roll");
                if (!diceScript.hasLanded)
                {
                    Show();
                }
                break;

            case GameState.Move:
                Debug.Log("GameState = Move");
                    Hide();
                    diceScript.Reset();
                break;

            default:
                Debug.LogError("Game is an invalid state!");
                return;
        }   
    }


    //Set button canvas to invisible and not interactable
    void Hide()
    {
        buttonCanvas.alpha = 0f;
        buttonCanvas.blocksRaycasts = false;
    }

    //Set button canvas to visible and interactable
    void Show()
    {
        buttonCanvas.alpha = 1f;
        buttonCanvas.blocksRaycasts = true;
    }

    //Restart game can be called to reload the entire game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
