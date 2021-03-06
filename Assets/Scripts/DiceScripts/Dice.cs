/**
 *  @file: Dice.cs
 *  Rolls the dice, checks dice value, and resets die to be thrown again
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //Main Dice references and variables
    Rigidbody rb;
    public bool hasLanded;
    public bool thrown;
    public bool badThrow;

    Vector3 initPos;
    public static int diceValue;
    public static int rolledValue;
    public DiceSide[] diceSides;

    //Audio ref
    public AudioSource rollDieSound;

    //other ref
    GameManager GM;
    public GameObject player1MoveButton;
    public GameObject player2MoveButton;
    public GameObject rollDiceButton;


    //Set initial states of Dice and buttons
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.useGravity = false;

        GM = FindObjectOfType<GameManager>();

        player1MoveButton.SetActive(false);
        player2MoveButton.SetActive(false);
    }

    //Allow dice to be thrown at the beginning of the turn
    public void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

            //Play sound
            if (!rollDieSound.isPlaying)
            {
                rollDieSound.Play();
            }
        }
    }

    //Get the value of the DiceSide on the ground
    void DiceValueCheck()
    {
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                rolledValue = side.sideValue;
            }
        }
    }

    //Call to reset dice to starting position and variable values
    public void Reset()
    {
        transform.position = initPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    //Calls DiceValueCheck if thrown and landed correctly
    private void Update()
    {
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValueCheck();

            //Show move player button only if dice gives a valid value
            if (GM.currentState == GameState.Player1Turn && hasLanded)
            {
                player1MoveButton.SetActive(true);
            }

            else if (GM.currentState == GameState.Player2Turn && hasLanded)
            {
                player2MoveButton.SetActive(true);
            }
        }
        //Allow another roll if dice lands incorrectly
        else if (rb.IsSleeping() && thrown && diceValue == 0)
        {
            rollDiceButton.SetActive(true);
        }
    }
}
