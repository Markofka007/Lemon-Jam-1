using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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

    private FistAttack fist;

    public Animator myAnimator;

    private Vector2 colliderOffset;  //offset

    public GameObject armSprite;

    public SpriteRenderer jamSprite;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        myAnimator.GetComponent<Animator>();

        fist = transform.GetChild(0).GetComponent<FistAttack>();

        colliderOffset = GetComponent<CapsuleCollider2D>().offset;  //offset

        jamSprite.GetComponent<SpriteRenderer>();

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
            myAnimator.SetBool("areyouIdle", false);

            if(jamSprite.flipX == true && canJump == true)
            {
                armSprite.transform.localPosition = new Vector3(0.089f, -0.514f, 0f);
            }

            if (jamSprite.flipX == true && canJump == false)
            {
                armSprite.transform.localPosition = new Vector3(-0.235f, -0.114f, 0f);
            }

        }

        else if (H_Input > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<CapsuleCollider2D>().offset = colliderOffset;
            myAnimator.SetBool("areyouIdle", false);

            if(jamSprite.flipX == false && canJump == true)
            {
                armSprite.transform.localPosition = new Vector3(-0.128f, -0.5f, 0f);
            }

            if (jamSprite.flipX == false && canJump == false)
            {
                armSprite.transform.localPosition = new Vector3(0.297f, -0.05f, 0f);
            }

        }

        else if (H_Input == 0)
        {
            if (jamSprite.flipX == true && canJump == false)
            {
                armSprite.transform.localPosition = new Vector3(-0.235f, -0.114f, 0f);
                if (rb.velocity.y == 0)
                {
                    armSprite.transform.localPosition = new Vector3(0.089f, -0.514f, 0f);
                }
            }

            if (jamSprite.flipX == false && canJump == false)
            {
                armSprite.transform.localPosition = new Vector3(0.297f, -0.05f, 0f);
                if(rb.velocity.y == 0)
                {
                    armSprite.transform.localPosition = new Vector3(-0.128f, -0.5f, 0f);
                }
            }


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
            myAnimator.SetBool("areyouIdle", true);
        }

        if (Mathf.Abs(rb.velocity.y) > 0.5)
        {
            myAnimator.SetBool("areyouRising", true);
            myAnimator.SetBool("areyouIdle", false);

        }

        if (rb.velocity.y < 0.5)
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
                equipedItem.GetComponent<AutoGun>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat>().MultiplyPower(powerM_Delta);
            }
            else if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC>().MultiplyPower(powerM_Delta);
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
                myAnimator.Play("Jam Melee", -1, 0f);
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun>().StartFire();
            }
            else if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow>().StartWind();
            }
            else if (equipedItem.name.Contains("RocketLauncher"))
            {
                equipedItem.GetComponent<RL>().Fire();
            }
            else if (equipedItem.name.Contains("Bat"))
            {
                equipedItem.GetComponent<Bat>().Fire();
            }
        }

        if (context.canceled)
        {
            if (equipedItem.name.Contains("Bellow"))
            {
                equipedItem.GetComponent<Bellow>().StopWind();
            }
            else if (equipedItem.name.Contains("Auto Gun"))
            {
                equipedItem.GetComponent<AutoGun>().StopFire();
            }
        }
    }

    public void Charge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (equipedItem.name.Contains("LaserCannon"))
            {
                equipedItem.GetComponent<LC>().Fire();
            }
        }
    }

    public void removeArm()
    {
        armSprite.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void returnArm()
    {
        armSprite.GetComponent<SpriteRenderer>().enabled = true;
    }
}
