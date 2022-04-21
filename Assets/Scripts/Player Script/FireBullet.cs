using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    public Animator anim;
    private bool canMove; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    IEnumerator bulletDisable(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Beetle" || target.gameObject.tag == "Snail"
            || target.gameObject.tag == "Spider" || target.gameObject.tag == "Boss")
        {
            gameObject.SetActive(true);
            anim.Play("Explode");
            canMove = false;
            //if (!canMove)
            //{
            //    target.gameObject.SetActive(false);
            //}
            StartCoroutine(bulletDisable(0.01f));
        }
    }
    
} //class
