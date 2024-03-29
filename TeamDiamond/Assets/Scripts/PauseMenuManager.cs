﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    bool pauseGame;
    bool helpMenu;

    private LevelMaster lm;

    public bool mute;

    public GameObject helpMenuPanel;



  


    public void ShowPause()
    {

        if (!helpMenu)
        {
            // Pause the game
            pauseGame = true;

            // Show the panel
            gameObject.SetActive(true);
        }

    }



   

    public void ShowHelp()
    {

        helpMenu = true;
        gameObject.SetActive(false);

        helpMenuPanel.SetActive(true);

    }

    public void BackButton()
    {

        if(helpMenu){
            helpMenuPanel.SetActive(false);
            gameObject.SetActive(true);
            helpMenu = false;


        }



    }


  


    // Hide the menu panel
    public void Hide()
    {
        // Deactivate the panel
        gameObject.SetActive(false);
        // Resume the game (if paused)
        pauseGame = false;
        Time.timeScale = 1f;
    }

    public void QuitApplication(){

        SceneManager.LoadScene("StartScreen");
    }


    private void Update()
    {
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();


        if (pauseGame)
        {
            Time.timeScale = 0;
        }
    }


}
