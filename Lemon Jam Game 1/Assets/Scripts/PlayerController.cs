using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    PlayerControlls controls;
    Vector2 move;

    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    private bool canJump;
    private bool canDoubleJump;

    private float H_Input;
    private float V_input;

    public LayerMask canJumpOn;


    private void Awake()
    {
        controls = new PlayerControlls();
        controls.Player1.Enable();
        controls.Player1.H_Movement.performed += Move;
    }
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, -3.25f, 0);
            rb.velocity = new Vector2(0, 0);
        }

        if (Physics2D.Raycast(transform.position + new Vector3(0, -0.75f, 0), Vector2.down, 0.1f, canJumpOn))
        {
            canJump = true;
            canDoubleJump = true;
        } else
        {
            canJump = false;
        }

        //H_Input = Input.GetAxisRaw("Horizontal");
        V_input = Input.GetAxisRaw("Vertical");

        
    }

    private void FixedUpdate()
    {
        H_Input = controls.Player1.H_Movement.ReadValue<float>();
        rb.AddForce(new Vector2(H_Input * moveSpeed, 0f), ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        if (rb.velocity.x < maxSpeed)
        {
            //rb.AddForce(new Vector2(moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    public void MoveLeft()
    {
        if (rb.velocity.x > -maxSpeed)
        {
            //rb.AddForce(new Vector2(-moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        //H_Input = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canJump)
            {
                rb.AddForce(new Vector2(0, jumpForce - rb.velocity.y), ForceMode2D.Impulse);
                canJump = false;
            }
            else if (canDoubleJump)
            {
                rb.AddForce(new Vector2(0, jumpForce - rb.velocity.y), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
    }
}
