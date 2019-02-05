using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerPos : MonoBehaviour {
    private GameMaster gm;
    private LevelMaster lm;



	// Use this for initialization
	void Start () {
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        if(lm.GetReset()){
            transform.position = gm.lastCheckpointPos;
        }
    }
	
	// Update is called once per frame
	
}
