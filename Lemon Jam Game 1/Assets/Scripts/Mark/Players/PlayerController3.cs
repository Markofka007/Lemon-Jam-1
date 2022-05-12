using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    private Rigidbody2D rb;

    private float H_Input;
    public float moveSpeed;
    public float maxSpeed;

    public float speedMultiplier;
    public float speedM_Delta;

    public float jumpForce;
    private bool canJump;
    private bool canDoubleJump;
    [SerializeField] private LayerMask canJumpOn;

    public float jumpMultiplier;
    public float jumpM_Delta;

    public float powerM_Delta;

    private Vector2 rightStick;
    public float controllerAngle;

    public GameObject equipedItem;

    private FistAttack3 fist;

    public Animator myAnimator;

    private Vector2 colliderOffset;

    public GameObject lemonArm;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        fist = transform.GetChild(0).GetComponent<FistAttack3>();

        myAnimator.GetComponent<Animator>();

        colliderOffset = GetComponent<CapsuleCollider2D>().offset;
    }

    void Update()
    {
        /*
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, -3.25f, 0);
            rb.velocity = new Vector2(0, 0);
        }
        */

        //flip
        if (H_Input < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<CapsuleCollider2D>().offset = colliderOffset * new Vector2(-1, 1);
            lemonArm.transform.localPosition = new Vector3(0.25f, -0.4f, 0f);
            myAnimator.SetBool("areyouIdle", false);

        }
        else if (H_Input > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<CapsuleCollider2D>().offset = colliderOffset;
            lemonArm.transform.localPosition = new Vector3(-0.128f, -0.5f, 0f);
            myAnimator.SetBool("areyouIdle", false);
        }

        if (Physics2D.Raycast(transform.position + new Vector3(0, GetComponent<CapsuleCollider2D>().offset.y - GetComponent<CapsuleCollider2D>().size.y / 2, 0), Vector2.down, 0.1f, canJumpOn))
        {
            canJump = true;
            canDoubleJump = true;
        }
        else
        {
            canJump = false;
        }


        controllerAngle = Mathf.Rad2Deg * Mathf.Atan2(rightStick.x, rightStick.y);

        if (transform.GetChild(0).GetChild(0).childCount == 1)
        {
            equipedItem = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        }

        //Animations
        if (Mathf.Abs(H_Input) > 0)
        {
            myAnimator.SetFloat("areyouWalking", Mathf.Abs(H_Input));
            myAnimator.SetBool("areyouIdle", false);
            myAnimator.SetBool("areyouRising", false);
        }
        else
        {
            myAnimator.SetFloat("areyouWalking", 0);
            lemonArm.transform.localPosition = new Vector3(0.167f, -0.34f, 0f);
            myAnimator.SetBool("areyouIdle", true);
        }

        if (rb.velocity.y > 0.5)
        {
            myAnimator.SetBool("areyouRising", true);
            myAnimator.SetBool("areyouIdle", false);

        }

        if(rb.velocity.y < 0)
        {
            myAnimator.SetBool("areyouRising", false);
            myAnimator.SetBool("areyouFalling", true);
            myAnimator.SetBool("areyouIdle", false);
        }

        if(rb.velocity.y == 0)
        {
            myAnimator.SetBool("areyouRising", false);
            myAnimator.SetBool("areyouFalling", false);
        }
    }

    private void FixedUpdate()
    {
        if (H_Input > 0 && rb.velocity.x < maxSpeed * speedMultiplier || H_Input < 0 && rb.velocity.x > -maxSpeed * speedMultiplier)
        {
            rb.AddForce(new Vector2(H_Input * moveSpeed * speedMultiplier, 0f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("JumpBean"))
        {
            Destroy(collision.gameObject);

            jumpMultiplier += jumpM_Delta;

            this.Wait(5.0f, () =>
            {
                jumpMultiplier -= jumpM_Delta;
            });
        }
        else if (collision.CompareTag("SpeedBean"))
        {
            Destroy(collision.gameObject);

            speedMultiplier += speedM_Delta;

            this.Wait(5.0f, () =>
            {
                speedMultiplier -= speedM_Delta;
            });
        }
        else if (collision.CompareTag("PowerBean"))
        {
            Destroy(collision.gameObject);

            if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun3>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow3>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL3>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat3>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC3>().MultiplyPower(powerM_Delta);
            }
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
                rb.AddForce(new Vector2(0, jumpForce * jumpMultiplier - rb.velocity.y), ForceMode2D.Impulse);
                canJump = false;
            }
            else if (canDoubleJump)
            {
                rb.AddForce(new Vector2(0, jumpForce * jumpMultiplier - rb.velocity.y), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (transform.GetChild(0).GetChild(0).childCount == 0)
            {
                fist.Punch();
                myAnimator.Play("Lem Melee", -1, 0f);
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun3>().StartFire();
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow3>().StartWind();
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL3>().Fire();
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat3>().Fire();
            }
        }

        if (context.canceled)
        {
            if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow3>().StopWind();
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun3>().StopFire();
            }
        }
    }

    public void Charge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC3>().Fire();
            }
        }
    }

    public void removeArm()
    {
        lemonArm.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void returnArm()
    {
        lemonArm.GetComponent<SpriteRenderer>().enabled = true;
    }
}
