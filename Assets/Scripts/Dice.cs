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

    //Get user input to roll dice
    private void Update()
    {
        //if (Input.touchCount > 0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        //allow dice to be reset if its not moving, and has been thrown.
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            DiceValueCheck();
            Reset();
        }
    }

    //Allow dice to fall and spin randomly if dice can be thrown 
    void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
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

    void DiceValueCheck()
    {
        diceValue = 0;
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
        
}
