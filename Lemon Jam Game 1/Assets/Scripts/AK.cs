using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    private GameObject currentBoundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player3 = GameObject.FindGameObjectWithTag("Player3");
        player4 = GameObject.FindGameObjectWithTag("Player4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Player1":
                
                break;

            case "Player2":

                break;

            case "Player3":

                break;

            case "Player4":

                break;

            default:
                Debug.Log("Collided with a non-player object!");
                break;
        }
    }
}
