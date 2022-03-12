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
    public AudioSource winSound;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    //Set the value of atHome if the player is on their home space
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("RedHome"))
        {
            redAtHome = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedFinish"))
        {
            if (!winSound.isPlaying)
            {
                winSound.Play();
            }
            GM.currentState = GameState.RedWin;
        }
    }

    //Set collision values to false when player leaves specific tiles
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("RedHome"))
        {
            redAtHome = false;
        }
    }

    //returns T/F value of collision with specific tiles
    public bool RedAtHome()
    {
        return redAtHome;
    }
}
