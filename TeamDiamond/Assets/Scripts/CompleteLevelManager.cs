using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteLevelManager : MonoBehaviour {

    public Text numResets = null;
    private LevelMaster game;

    public GameObject endGameResets;







    public GameObject completelevel;


    // Use this for initialization
    void Start () {


        completelevel.SetActive(false);
        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        endGameResets = GameObject.FindGameObjectWithTag("Resets");


    }

    // Update is called once per frame
    void Update () {
        //endGameResets.AddComponent. = "Total Resets: " + game.resets;


		
	}

    public void ShowMenu(){
        completelevel.SetActive(true);

    }
}
