using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlatform : MonoBehaviour
{
    private Rigidbody2D rb;//Reference to the rigidbody on the platform
    private int numPlayers = 0;//Number of players on the platform

    public float lowestY;//the lowest y value the platform can sink down to
    public float weight;//how fast the platform decends

    private Vector2 zero = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();//get the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > lowestY && numPlayers > 0)//if the platform is above its lowest level and at least one player is on it
        {
            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.down * weight, ref zero, 0.2f);
            //rb.velocity = Vector2.down * weight;//apply a downward force with the value of weight
        } 
        else//otherwise stop the platform from moving
        {
            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.zero, ref zero, 0.2f);
            //rb.velocity = Vector2.zero;//stop movement
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //A player has gone onto the platform
        if (collision.gameObject.tag.Contains("Player"))
        {
            numPlayers++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //A player has left the platform
        if (collision.gameObject.tag.Contains("Player"))
        {
            numPlayers--;
        }
    }
}
