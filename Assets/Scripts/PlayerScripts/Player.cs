﻿/**
 * @file: Player.cs
 *        Main blue player script calculates movement along board
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Player Components and references
    public Rigidbody playerRB;
    public int routePos;
    bool isMoving;

    public GameObject bluePlayer;

    //Other gameobject referecnes
    public Route currentRoute;
    public GameObject blueStart;

    //Sub-scripts references
    [SerializeField]
    internal PlayerCollision collisionScript;

    public Dice diceScript;

    private void Start()
    {
        blueStart = GameObject.FindGameObjectWithTag("BlueStart");
        bluePlayer = GameObject.Find("BluePlayer");
    }


    //Moves player postition along board according to dice values
    public void MovePlayer()
    {
        //Movement along the active playing route 
        if (!isMoving && !collisionScript.atHome)
        {
            //Avoiding overflow if routePos+DiceSideValue is greater than the amount of spaces left to move
            if (routePos + Dice.diceValue < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("NO moves! End turn");
            }
        }

        //Movement from home space to start space on the route.
        else if (!isMoving && collisionScript.atHome)
        {

            if (Dice.diceValue == 6)
            {
                //Good place for animation///

                transform.position = blueStart.transform.position;

                Dice.diceValue = 0;
            }

            else
            {
                Debug.Log("NO moves! End turn");  //Show in UI
            }

        }
    }

    //Using coroutine instead of update method for optimization
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        //Allowing movement of player along route using rolled die value
        while (Dice.diceValue > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePos + 1].position;
            while (MoveToNextTile(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            Dice.diceValue -= 1;
            routePos += 1;
        }

        isMoving = false;
    }

    //Checks if the tile to move towards is available
    bool MoveToNextTile(Vector3 tile)
    {
        return tile != (transform.position = Vector3.MoveTowards(transform.position, tile, 2f * Time.deltaTime));
    }
}