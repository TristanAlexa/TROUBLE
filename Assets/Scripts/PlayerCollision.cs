using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handling Blue Player collision

//Need 2 more specific player player collision scripts, to check collision between the two players
public class PlayerCollision : MonoBehaviour
{
    //Refernce main player script
    [SerializeField]
    Player playerScript;
    
    internal bool atHome;
    internal bool enteredStart;

    //Set the value of atHome if the player is on their home space
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = true;
            Debug.Log("This pawn is at home:" +gameObject.name);
        }
    }

    //When player first collides with start tile set the value of enteredStart
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueStart"))
        {
            enteredStart = true;
        }

        //Use in onTriggerEvent to send player back if land on same pos
    }

    //Set collision values to false when player leaves specific tiles
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = false;
        }

        if (collision.gameObject.CompareTag("BlueStart"))
        {
            enteredStart = false;
        }
    }

    //returns T/F value of collision with specific tiles
    public bool AtHome()
    {
        return atHome;
    }

    public bool EnteredStart()
    {
        return enteredStart;
    }

}
