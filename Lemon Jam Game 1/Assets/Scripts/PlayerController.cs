using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    private bool canDoubleJump = false;

    private float H_Input;
    private float V_input;

    public LayerMask canJumpOn;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, -3.25f, 0);
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Physics2D.Raycast(transform.position + new Vector3(0, -0.75f, 0), Vector2.down, 0.1f, canJumpOn))
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.AddForce(new Vector2(0, jumpForce - rb.velocity.y), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }

        H_Input = Input.GetAxisRaw("Horizontal");
        V_input = Input.GetAxisRaw("Vertical");

        
    }

    private void FixedUpdate()
    {
        

        if (H_Input > 0 && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector2(H_Input * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        if (H_Input < 0 && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(H_Input * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }
}
