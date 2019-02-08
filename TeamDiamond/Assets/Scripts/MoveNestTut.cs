using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNestTut : MonoBehaviour {

    private Vector3 nest1 = new Vector3(-66.6f, -3.6f, 0);
    private Vector3 nest2 = new Vector3(-3.9f, -3.6f, 0);
    private Vector3 nest3 = new Vector3(42.2f, -3.6f, 0);

    private Vector3 player1 = new Vector3(-66.4f, -2.4f, 0);
    private Vector3 player2 = new Vector3(-3.7f, -2.4f, 0);
    private Vector3 player3 = new Vector3(42.1f, -2.4f, 0);

    private Vector3 chick1 = new Vector3(-34f, -1.6f, 0);
    private Vector3 chick2 = new Vector3(15.3f, -3.5f, 0);
    private Vector3 chick3 = new Vector3(69f, -3.5f, 0);

    private int section = 0;
    private bool setLocation = true;

    private LevelMaster game;
    private GameMaster gm;

    private GameObject player;
    private GameObject chick;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();


        chick = GameObject.FindGameObjectWithTag("Chick");

        transform.position = nest1;
        player.transform.position = player1;
        chick.transform.position = chick1;
	}

    private void FixedUpdate()
    {
        if(section == 1 && setLocation){
            gm.chickLastCheckpoint = chick2;
            gm.lastCheckpointPos = player2;
            transform.position = nest2;
            player.transform.position = player2;
            chick.transform.position = chick2;
            setLocation = false;
        }
        else if(section == 2 && setLocation){
            gm.chickLastCheckpoint = chick3;
            gm.lastCheckpointPos = player3;
            transform.position = nest3;
            player.transform.position = player3;
            chick.transform.position = chick3;
            setLocation = false;
        }
        else if(section > 2 && setLocation){
            setLocation = false;

            game.LevelFinish();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Chick") && transform.position == nest1){
            section = 1;setLocation = true;
        }else if(collision.CompareTag("Chick") && transform.position == nest2) {
            section = 2;setLocation = true;
        }else if(collision.CompareTag("Chick") && transform.position == nest3) {
            section = 3;setLocation = true;
        }
    }
}
