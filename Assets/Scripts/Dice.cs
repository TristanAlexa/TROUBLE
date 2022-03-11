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
    public bool hasLanded;
    public bool thrown;

    Vector3 initPos;
    public static int diceValue;
    public DiceSide[] diceSides;

    GameManager GM;


    //Get the rb component of dice, and starting position in air to drop dice from
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPos = transform.position;
        rb.useGravity = false;

        GM = FindObjectOfType<GameManager>();
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
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + "has been rolled!");
            }
        }
    }

    //When player turn is done, or player needs to roll again (rolling a 6), set dice to starting position and variable values
    public void Reset()
    {
        transform.position = initPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    //Check value of dice after it was thrown
    private void Update()
    {
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValueCheck();
        }
    }

}
