using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private  Text CoinScore;
    private AudioSource audioManager;
    private int scoreCount;

    void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        CoinScore = GameObject.Find("CoinText").GetComponent<Text>(); 
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
         if(target.tag == "Coin")
        {
            target.gameObject.SetActive(false);
            scoreCount++;

            CoinScore.text = "x" + scoreCount;

            audioManager.Play();

        }
    }

}  // class
