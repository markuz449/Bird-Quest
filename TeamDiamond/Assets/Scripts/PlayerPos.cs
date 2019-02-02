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

        if(lm.getReset()){
            transform.position = gm.lastCheckpointPos;


        }


    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R)){
            var currentScene = SceneManager.GetActiveScene();
            var currentSceneName = currentScene.name;

            lm.PlayerReset();

            // Load the "Level" scene
            SceneManager.LoadScene(currentSceneName);

        }
	}
}
