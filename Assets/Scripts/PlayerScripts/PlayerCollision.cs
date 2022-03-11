using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handling Blue Player collision

public class PlayerCollision : MonoBehaviour
{
    //Refernce main player script
    [SerializeField]
    Player playerScript;
    
    internal bool atHome;
   
    //Set the value of atHome if the player is on their home space
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = true;
            Debug.Log("This pawn is at home:" +gameObject.name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Use in onTriggerEvent to send player back if land on same pos
    }

    //Set collision values to false when player leaves specific tiles
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = false;
        }
    }

    //returns T/F value of collision with specific tiles
    public bool AtHome()
    {
        return atHome;
    }

}
