using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEggScript : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
            //Damage the player
        {
        }
        gameObject.SetActive(false);
    }
  
}
