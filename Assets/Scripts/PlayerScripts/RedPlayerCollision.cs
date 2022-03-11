using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerCollision : MonoBehaviour
{
    [SerializeField]
    RedPlayer redPlayerScript;

    internal bool redAtHome;

    //Other ref.
    GameManager GM;
    GameObject bluePlayer;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        bluePlayer = GameObject.Find("BluePlayer");
    }

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
        if (other.gameObject.CompareTag("RedFinish"))
        {
            GM.currentState = GameState.BlueWin;
        }

       //if moveback home function was here. The player would be sent home when pther player passes by.
       //Instead only move back home when player stops moving on it.
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
