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
            Debug.Log("Blue Player is at home");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = false;
            Debug.Log("Blue Player has left home");
        }
    }

    //returns T/F value of atHome 
    public bool AtHome()
    {
        return atHome;
    }

}
