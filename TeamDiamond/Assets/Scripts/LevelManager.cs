using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 

public class LevelManager : MonoBehaviour {

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;


    public void CompleteLevel1()
    {

        SceneManager.LoadScene("JaydinMainMenuTest");





    }

    public void MainMenuOpen()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinMainMenuTest");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.ShowPause();

    }

    private void Start()
    {
        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }
}
