using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlatform : MonoBehaviour
{
    private bool isOn = false;//Bool for whether or not a player is on the platform
    private Rigidbody2D rb;//Reference to the rigidbody on the platform
    private int numPlayers = 0;//Number of players on the platform

    public float lowestY;//the lowest y value the platform can sink down to
    public float weight;//how fast the platform decends

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//get the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > lowestY && numPlayers > 0)//if the platform is above its lowest level and at least one player is on it
        {
            rb.velocity = Vector2.down * weight;//apply a downward force with the value of weight
        } 
        else//otherwise stop the platform from moving
        {
            rb.velocity = Vector2.zero;//stop movement
        }

        //Debug.Log(numPlayers);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //A player has gone onto the platform
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player3") || collision.gameObject.CompareTag("Player4"))
        {
            isOn = true;
            numPlayers++;
            Debug.Log("Yerr");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2") || collision.gameObject.CompareTag("Player3") || collision.gameObject.CompareTag("Player4"))
        {
            isOn = false;
            numPlayers--;
        }
    }
}
