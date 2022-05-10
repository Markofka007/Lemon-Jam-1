using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakawayPlatform : MonoBehaviour
{
    //public Component anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player1") || (collision.gameObject.tag == "Player2") || (collision.gameObject.tag == "Player3") || (collision.gameObject.tag == "Player4"))
        {
            gameObject.GetComponent<Animator>().Play("Breaking");
            
            this.Wait(1f, () =>
            {
                Destroy(gameObject);
            });
        }
    }
}
