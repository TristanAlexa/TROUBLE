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
        Debug.Log("Blue start is available");
    }

    //Updates player position along board according to dice values
    private void Update()
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
                //If this happens, no moves are available. Tell the player, thus presses end turn/////
                Debug.Log("rolled number is too high!");
            }
        }
        
        //Movement from home space to start space on the route.
        else if (!isMoving && collisionScript.atHome)
        {
        
            if(Dice.diceValue == 6)
            {
                MoveToNextTile(blueStart.transform.position);
                Dice.diceValue = 1;
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

    bool MoveToNextTile(Vector3 tile)
    {
        //Checking if a player is already moving.
        return tile != (transform.position = Vector3.MoveTowards(transform.position, tile, 2f * Time.deltaTime));
        
    }
}
