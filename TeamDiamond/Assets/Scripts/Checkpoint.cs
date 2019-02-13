using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private GameMaster gm;
    private LevelMaster lm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){
            lm.checkpointReached = true;

            gm.lastCheckpointPos = transform.position;

        } else if(other.CompareTag("Chick") )

        {
            lm.checkpointReached = true;

            gm.chickLastCheckpoint = transform.position;


        }


    }

    private void Update()
    {
        if(gm.lastCheckpointPos == transform.position){
            transform.GetComponent<Collider2D>().enabled = false;
        }else
        {
            transform.GetComponent<Collider2D>().enabled = true;
}
    }
}
