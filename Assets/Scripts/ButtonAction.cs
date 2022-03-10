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
    GameObject rollDiceButton;
    GameObject endTurnButton;
    GameManager GM;

    //Find all referenced GameObjects in scene
    void Start()
    {
        rollDiceButton = GameObject.Find("RollDie");
        endTurnButton = GameObject.Find("EndTurn");
        endTurnButton.SetActive(false);
        
        GM = FindObjectOfType<GameManager>();
    }

    //After roll dice is pressed change visible state of buttons
    public void RollDiePressed()
    {
        rollDiceButton.SetActive(false);
        endTurnButton.SetActive(true);
    }

    //On end turn pressed, change game and button states
    public void EndTurnPressed()
    {
        endTurnButton.SetActive(false);
        rollDiceButton.SetActive(true);
        
        GM.currentState = GameState.Roll;
    }
}
