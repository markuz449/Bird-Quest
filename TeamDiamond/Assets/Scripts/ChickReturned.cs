using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickReturned : MonoBehaviour {

    public GameObject levelCompleteScreen;

    private LevelMaster lm;

    private void Start()
    {
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nest"))
        {


            lm.LevelFinish();
        }
    }
    }
