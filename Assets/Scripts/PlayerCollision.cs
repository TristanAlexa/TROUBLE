using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handling Blue Player collision
public class PlayerCollision : MonoBehaviour
{

    public Rigidbody bluePlayerRB;
    public bool atHome;


    private void Start()
    {
        bluePlayerRB = GetComponent<Rigidbody>();
    }

    //Set the value of atHome if the player is on their home space
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = true;
            Debug.Log("Blue Player is at home");
        }
    }

    private void OnCollisionExit(Collision collision)
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
