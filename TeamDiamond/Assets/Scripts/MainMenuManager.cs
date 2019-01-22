using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    // Reference to panel's script object 
    PauseMenuManager pauseMenu;

    public void StartNestLevel()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinNestLevelTest");
    }

    public void MainMenuOpen()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinMainMenuTest");
    }

    public void StartChickLevel1()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinChickLevel1Test");
    }

    public void StartChickLevel2()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinChickLevel2Test");
    }

    public void OpenPauseMenu(){
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