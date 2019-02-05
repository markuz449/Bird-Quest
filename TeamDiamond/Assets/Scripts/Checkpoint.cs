using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            gm.lastCheckpointPos = transform.position;

        } else if(other.CompareTag("Chick") || other.CompareTag("TutorialChick"))
        {
            gm.chickLastCheckpoint = transform.position;


        }


    }
}
