using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {

    bool pauseGame;
    bool optionMenu;

    public GameObject optionsMenuPanel;

    public GameObject helpMenuPanel;



    public void ShowPause()
    {
        // Pause the game
        pauseGame = true;

        // Show the panel
        gameObject.SetActive(true);

    }

    public void ShowOptions()
    {

        optionMenu = true;
        // Show the panel

        gameObject.SetActive(false);

        optionsMenuPanel.SetActive(true);

    }

    public void ShowHelp()
    {

       
        gameObject.SetActive(false);

        helpMenuPanel.SetActive(true);

    }

    public void BackButton()
    {

        if(optionMenu){
            optionsMenuPanel.SetActive(false);
            gameObject.SetActive(true);
            optionMenu = false;



        }
        else {

            helpMenuPanel.SetActive(false);
            gameObject.SetActive(true);


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

        Application.Quit();
    }


    private void Update()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
    }


}
