using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Use in onTriggerEvent to send player back if land on same pos
    public int routePos;
    public Route currentRoute;
    public static int valueToMove;
    bool isMoving;
    private void Update()
    {
        
        //Handle Screen touches
        //If player has tapped the die space roll the die
        //if (Input.touchCount > 0 && !isMoving)
        
        if (Input.touchCount > 0 && !isMoving)
        {
            valueToMove = Dice.diceValue;
            //Avoiding overflow if routePos+DiceSideValue is greater than the amount of spaces left to move
            if (routePos + valueToMove < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                //Or go to next player turn
                Debug.Log("rolled number is too high!");
            }
        }
    }

    //Using coroutine instead of update method for optimazation
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        //Allowing movement of player
        while (valueToMove > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePos + 1].position;
            while (MoveToNextTile(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            valueToMove -= 1;
            routePos += 1;
        }

        isMoving = false;
    }

    bool MoveToNextTile(Vector3 tile)
    {
        //Checking if a player is already moving.
        return tile != (transform.position = Vector3.MoveTowards(transform.position, tile, 2f * Time.deltaTime));
        
    }
}
