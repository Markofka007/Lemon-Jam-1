using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    private bool canJump;
    private bool canDoubleJump;
    private float H_Input;
    [SerializeField] private LayerMask canJumpOn;

    private Vector2 rightStick;


    public float controllerAngle;


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
        }
        else
        {
            canJump = false;
        }


        controllerAngle = Mathf.Rad2Deg * Mathf.Atan2(rightStick.x, rightStick.y);
    }

    private void FixedUpdate()
    {
        if (H_Input > 0 && rb.velocity.x < maxSpeed || H_Input < 0 && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(H_Input * moveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        H_Input = context.ReadValue<float>();
    }

    public void Aim(InputAction.CallbackContext context)
    {
        rightStick = context.ReadValue<Vector2>();

        //Debug.Log(rightStick);
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

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.GetChild(0).GetChild(0).GetComponent<AutoGun>().Fire();
        }
    }
}
