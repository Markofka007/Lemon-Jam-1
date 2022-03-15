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


    private Camera mainCam;

    private Vector3 mousePos;
    private Vector3 localMousePos;
    private float angleToMouse;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        mainCam = Camera.main;
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


        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        localMousePos = mousePos - transform.position;
        angleToMouse = Mathf.Rad2Deg * Mathf.Atan2(localMousePos.x, localMousePos.y);
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
