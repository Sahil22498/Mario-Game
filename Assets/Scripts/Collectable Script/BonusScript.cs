using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{

    public Transform bottom_Collision;
    public Animator anim;
    public LayerMask playerLayer;

    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnimate = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;

    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }
   
    void CheckForCollision()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottom_Collision.position, Vector2.down, 0.01f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    //increase score
                   anim.Play("Idle");
                   startAnim = true;
                }
            } 
        }
    }

    void AnimateUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);
            if (transform.position.y >= animPosition.y)
            {
                moveDirection = Vector3.down;
            } else if (transform.position.y <= originPosition.y)
            {
                startAnim = false;
            }
        }
    }

} // class
