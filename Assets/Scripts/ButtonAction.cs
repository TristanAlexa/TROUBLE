/**
 * @file: ButtonAction.cs
 *        Handles button functionality and state management
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    //Button references
    GameObject rollDiceButton;
    GameObject endTurnButton;
    GameObject player1MoveButton;
    GameObject player2MoveButton;

    //Other referecnes
    GameManager GM;
    GameObject bluePlayer;
    GameObject redPlayer;

    //Find all referenced GameObjects in scene. Set initial button visibility
    void Start()
    {
        rollDiceButton = GameObject.Find("RollDie");
        endTurnButton = GameObject.Find("EndTurn");
        player1MoveButton = GameObject.Find("BluePlayer1Button");
        player2MoveButton = GameObject.Find("BluePlayer2Button");
        bluePlayer = GameObject.Find("BluePlayer");
        redPlayer = GameObject.Find("RedPlayer");

        endTurnButton.SetActive(false);
        player1MoveButton.SetActive(false);
        player2MoveButton.SetActive(false);

        GM = FindObjectOfType<GameManager>();
    }

    //After roll dice is pressed show a move Red or Blue player button
    public void RollDiePressed()
    {
        rollDiceButton.SetActive(false);
        

        if (GM.currentState == GameState.Player1Turn)
        {

            player1MoveButton.SetActive(true);
        }

        else if (GM.currentState == GameState.Player2Turn)
        {
            player2MoveButton.SetActive(true);
        }
    }

    //Move blue pawn if able and reveal end turn button
    public void Player1MovePressed()
    {
        //call move function from blue game object
        bluePlayer.GetComponent<Player>().MovePlayer();
        player1MoveButton.SetActive(false);
        endTurnButton.SetActive(true);
    }

    //Move red pawn if able and reveal end turn button
    public void Player2MovePressed()
    {
        //call move fucntion from
        redPlayer.GetComponent<RedPlayer>().MovePlayer();
        player2MoveButton.SetActive(false);
        endTurnButton.SetActive(true);
    }

    //On end turn pressed, change player turn and button states
    public void EndTurnPressed()
    {
        endTurnButton.SetActive(false);
        rollDiceButton.SetActive(true);

        //switch to next player turn
        if (GM.currentState == GameState.Player1Turn)
        {
            GM.currentState = GameState.Player2Turn;
        }

        else if (GM.currentState == GameState.Player2Turn)
        {
            GM.currentState = GameState.Player1Turn;
        }
    }
}
