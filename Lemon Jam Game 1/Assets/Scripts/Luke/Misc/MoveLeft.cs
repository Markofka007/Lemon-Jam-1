using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Velo = 7;

    // Update is called once per frame
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Velo, 0);
    }
}
