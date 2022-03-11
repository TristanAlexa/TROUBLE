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

public enum GameState {Player1Turn, Player2Turn, Win}; 

//set player pawns to variable numbers ie, 1,2,3,4. Can do 1 pawn per player
//Start with first player, on end turn button -> switch to the other player turn
//In Player.cs instead of move(coroutine) in Update, add a separate function for allowing movement.
//Button Action Roll button should initiate roll game state?????
//In game manager roll, whichever pawn turn it is call the move function for that pawn
public class GameManager : GenericSingleton<GameManager>
{
    //used to change state of game
    public GameState currentState;
    public int playerTurn;

    //Script References
    public Dice diceScript;
    public Player playerScript;

    private void Start()
    {

        currentState = GameState.Player1Turn;
        
    }

    //Game state code is immediately executed when when a new game state is called
    private void Update()
    {
        switch (currentState)
        {
            case GameState.Player1Turn:
                Debug.Log("GameState = Blue's Turn");
                playerTurn = 1;
                break;

            case GameState.Player2Turn:
                Debug.Log("GameState = Red's Turn");
                playerTurn = 2;
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
