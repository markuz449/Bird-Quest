using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickReturned : MonoBehaviour {

    public GameObject levelCompleteScreen;

    private LevelMaster lm;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nest"))
        {


            lm.LevelFinish();
        }
    }

    private void Start()
    {
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

    }
}
