using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public GameObject stone;
    public Transform attackInstantiate;

    private Animator anim;
    private string couroutine_Name = "StartAttack";

     void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(couroutine_Name);
    }
    
    void Attack()
    {
        GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700), 0f));
    } 

    void BackToIdle()
    {
        anim.Play("BossIdle");
    }

    public void DeactivateBossScript()
    {
        StopCoroutine(couroutine_Name);
        enabled = false;
    }
        IEnumerator StartAttack()
        {
            yield return new WaitForSeconds(Random.RandomRange (2f,5f));

            anim.Play("BossAttack");
            StartCoroutine(couroutine_Name);
        }

    // Update is called once per frame
    void Update()
    {
        
    }

}  //class
