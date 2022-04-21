using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D myBody;

    public Animator anim;

    public Transform GroundCheckPosition;
    public LayerMask GroundLayer;

    private bool isGrounded;
    private bool jumped;

    public float jumpPower = 20f;


    void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }


    void Update()
    {
        CheckIfGrounded();
        PlayerJump();

    }

    void FixedUpdate()
    {
        PlayerWalk();

    }

    void PlayerWalk()
    {

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangeDirection(1);

        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangeDirection(-1);

        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);

        }
        anim.SetInteger("speed", Mathf.Abs((int)myBody.velocity.x));

    }
    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void CheckIfGrounded()
    {
        //print(GroundLayer);
        isGrounded = Physics2D.Raycast(GroundCheckPosition.position, Vector2.down, 0.1f, GroundLayer);
       //  print(isGrounded);
        if (isGrounded)
        {
            if (jumped)
            {
                jumped = false;
                anim.SetBool("Jump", false);
            }
        }
    }
    void PlayerJump()
    {
        // print("out of if");

        if (isGrounded)
        {
           // print("is grounded");

            if (Input.GetKey(KeyCode.Space))
            {
                //  Debug.Log("pppppppppppppppppppppppp");
                jumped = true;

                myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);

                anim.SetBool("Jump", true);
            }
        }
    }

} //class
