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

    //other ref.
    GameManager GM;
    public AudioSource winSound;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    //Set the value of atHome if the player is on their home space
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = true;
        }
    }

    //Set collision values to false when player leaves specific tiles
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            atHome = false;
        }
    }

    //returns T/F value of collision with home tile
    public bool AtHome()
    {
        return atHome;
    }

    //Play win sfx and change to win state on collision with final tile
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueFinish"))
        {
            if (!winSound.isPlaying)
            {
                winSound.Play();
            }
            GM.currentState = GameState.BlueWin;
        }
    }

}
