using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrogScript : MonoBehaviour
{
    private Animator anim;
    private bool animation_Started;
    private bool animation_Finished;
   
    private int jumpedTimes;
    private bool jumpLeft = true;

    private string coroutine_name = "FrogJump";

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutine_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {

        }
        StartCoroutine(coroutine_name);
    }
    
    void AnimationFinished()
    {
      anim.Play("FrogIdleLeft");
    }
} //class
