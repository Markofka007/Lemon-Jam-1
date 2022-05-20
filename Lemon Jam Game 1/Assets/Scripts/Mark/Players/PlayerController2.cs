using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
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

    private FistAttack2 fist;

    public Animator myAnimator;
    public GameObject jumpBoostFx;
    public GameObject speedBoostFx;
    public GameObject powerBoostFx;

    public Vector3 myPos;
    private Vector2 colliderOffset;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        myAnimator.GetComponent<Animator>();

        fist = transform.GetChild(0).GetComponent<FistAttack2>();

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
        myPos = transform.position;
        //flip
        if (H_Input < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<CapsuleCollider2D>().offset = colliderOffset * new Vector2(-1, 1);
            myAnimator.SetBool("areyouIdle", false);
        }
        else if (H_Input > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<CapsuleCollider2D>().offset = colliderOffset;
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


        if (rb.velocity.y > 0.5)
        {
            myAnimator.SetBool("areyouRising", true);
            myAnimator.SetBool("areyouIdle", false);

        }

        if (rb.velocity.y < 0)
        {
            myAnimator.SetBool("areyouRising", false);
            myAnimator.SetBool("areyouFalling", true);
            myAnimator.SetBool("areyouIdle", false);
        }

        if (rb.velocity.y == 0)
        {
            myAnimator.SetBool("areyouRising", false);
            myAnimator.SetBool("areyouFalling", false);
        }

        if (rb.velocity.y == 0 && myAnimator.GetFloat("areyouWalking") < 0.1)
        {
            myAnimator.SetBool("areyouIdle", true);
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
            Instantiate(jumpBoostFx, myPos, Quaternion.identity, transform);

            jumpMultiplier += jumpM_Delta;

            this.Wait(5.0f, () =>
            {
                jumpMultiplier -= jumpM_Delta;
            });
        }
        else if (collision.CompareTag("SpeedBean"))
        {
            Destroy(collision.gameObject);
            Instantiate(speedBoostFx, myPos, Quaternion.identity, transform);

            speedMultiplier += speedM_Delta;

            this.Wait(5.0f, () =>
            {
                speedMultiplier -= speedM_Delta;
            });
        }
        else if (collision.CompareTag("PowerBean"))
        {
            Destroy(collision.gameObject);
            Instantiate(powerBoostFx, myPos, Quaternion.identity, transform);

            if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun2>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow2>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL2>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat2>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC2>().MultiplyPower(powerM_Delta);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        H_Input = context.ReadValue<float>();

        //Walk Animation
        if (Mathf.Abs(H_Input) > 0)
        {
            myAnimator.SetFloat("areyouWalking", Mathf.Abs(H_Input));
            myAnimator.SetBool("areyouIdle", false);
            myAnimator.SetBool("areyouRising", false);
        }
        else
        {
            myAnimator.SetFloat("areyouWalking", 0);
            myAnimator.SetBool("areyouIdle", true);
        }

    }

    public void Aim(InputAction.CallbackContext context)
    {
        rightStick = context.ReadValue<Vector2>();
    }

    public void mouseAim(InputAction.CallbackContext context)
    {
        rightStick = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position;  //Mouse support
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canJump)
            {
                rb.AddForce(new Vector2(0, jumpForce * jumpMultiplier - rb.velocity.y), ForceMode2D.Impulse);
                canJump = false;
                //myAnimator.Play("Bub fall", -1, 0f);
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
                myAnimator.Play("Bub melee", -1, 0f);
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun2>().StartFire();
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow2>().StartWind();
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL2>().Fire();
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat2>().Fire();
            }
        }

        if (context.canceled)
        {
            if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow2>().StopWind();
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun2>().StopFire();
            }
        }
    }

    public void Charge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC2>().Fire();
            }
        }
    }
}
