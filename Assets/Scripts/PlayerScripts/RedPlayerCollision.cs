using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerCollision : MonoBehaviour
{
    [SerializeField]
    RedPlayer redPlayerScript;

    internal bool redAtHome;

    //Set the value of atHome if the player is on their home space
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("RedHome"))
        {
            redAtHome = true;
            Debug.Log("This pawn is at home:" + gameObject.name);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //Use in onTriggerEvent to send player back if land on same pos
    }

    //Set collision values to false when player leaves specific tiles
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("RedHome"))
        {
            redAtHome = false;
            Debug.Log("This pawn left home:" + gameObject.name);
        }
    }

    //returns T/F value of collision with specific tiles
    public bool RedAtHome()
    {
        return redAtHome;
    }
}
