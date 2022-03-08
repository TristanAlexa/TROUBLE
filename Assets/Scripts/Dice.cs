/**
 *  @file: Dice.cs
 *  Rolls the dice, checks dice value, and resets die to be thrown again
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPos;

    public static int diceValue;
    public DiceSide[] diceSides;


    //get the rb component of dice, and starting position in air to drop dice from
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.useGravity = false;
    }

    //Allow dice to be thrown at the beginning of the turn
    public void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
    }

    //Get the value of the DiceSide on the ground. Set equal to diceValue
    void DiceValueCheck()
    {
        //diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + "has been rolled!");
                //can bring this value into gamemanager, or player to move the player
            }
        }
    }

    //When player turn is done, or player needs to roll again (rolling a 6), set dice to starting position and variable values
    private void Reset()
    {
        transform.position = initPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    //If the dice was thrown on the player turn, check the value and reset the dice position
    private void Update()
    {
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValueCheck();
            Reset();
        }
    }

}
