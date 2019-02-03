using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickReturned : MonoBehaviour {

    LevelManager lm;
    public GameObject nest;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TutorialChick") || collision.CompareTag("Chick"))
        {
            lm.LevelFinish();


        }
    }



    private void Start()
    {
        lm = nest.AddComponent<LevelManager>();
    }
}
