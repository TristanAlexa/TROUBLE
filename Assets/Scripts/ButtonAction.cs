/**
 * @file: ButtonAction.cs
 *        Handles button functionality and state management
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonAction : MonoBehaviour
{
    //Button references
    GameObject rollDiceButton;
    GameObject endTurnButton;
    GameObject player1MoveButton;
    GameObject player2MoveButton;
    GameObject endGameButton;

    //Other referecnes
    GameManager GM;
    GameObject bluePlayer;
    GameObject redPlayer;
    public TextMeshProUGUI redWinsText;
    public TextMeshProUGUI blueWinsText;

    //Find all referenced GameObjects in scene. Set initial button visibility
    void Start()
    {
        rollDiceButton = GameObject.Find("RollDie");
        endTurnButton = GameObject.Find("EndTurn");
        player1MoveButton = GameObject.Find("BluePlayer1Button");
        player2MoveButton = GameObject.Find("BluePlayer2Button");
        bluePlayer = GameObject.Find("BluePlayer");
        redPlayer = GameObject.Find("RedPlayer");
        endGameButton = GameObject.Find("EndGameButton");

        endTurnButton.SetActive(false);
        player1MoveButton.SetActive(false);
        player2MoveButton.SetActive(false);
        endGameButton.SetActive(false);

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
        redPlayer.GetComponent<RedPlayer>().MovePlayer();
        player2MoveButton.SetActive(false);
        endTurnButton.SetActive(true);
    }

    //On end turn pressed, change player turn (with sfx) and button states
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

        //Show restart game button if in winning state
        else if (GM.currentState == GameState.RedWin)
        {
            endGameButton.SetActive(true);
        }
        else if (GM.currentState == GameState.BlueWin)
        {
            endGameButton.SetActive(true);
        }
    }

    //Restart game can be called to reload the entire game
    public void EndGamePressed()
    {
        Destroy(blueWinsText);
        Destroy(redWinsText);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
