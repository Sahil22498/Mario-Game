using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    private Animator anim;
    private int health = 10;

    private bool canDamage; 

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds (2f);
        canDamage = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            if (target.tag == "Bullet")
            {
                health--;
                canDamage = true;

                if (health == 0)
                {
                    //Deactivate Boss Script
                    GetComponent<BossScript>().DeactivateBossScript();
                    anim.Play("BossDead");

                    gameObject.SetActive(false);
                }
               
                StartCoroutine(WaitForDamage ());
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
