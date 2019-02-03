using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelManager : MonoBehaviour {

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject levelCompletePanel;
    public Text numResets;
    private LevelMaster game;
    private GameObject text1;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;
    CompleteLevelManager levelComplete;



    public void CompleteLevel1()
    {
        SceneManager.LoadScene("JaydinMainMenuTest");
        game.ClearReset();

        game.UnlockLevel1();






    }


    public void LevelFinish(){
        levelComplete = levelCompletePanel.GetComponent<CompleteLevelManager>();
        int numresets = game.getNumResets();

        numResets.text = "Total Resets: " + numresets.ToString();
        //GameObject resetText;
        //text1 = GameObject.FindGameObjectWithTag("Resets");

        //resetText = GameObject.FindGameObjectWithTag("Resets").GetComponent<GameObject>();
        //Debug.Log(text1.GetType()); 

        //= numresets.ToString();

        levelComplete.ShowMenu();

    }

    public void ReloadLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        game.PlayerReset();

        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void RetryLevel()
    {
        game.ClearReset();

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;


        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenuOpen()
    {
        game.ClearReset();

        // Load the "Level" scene
        SceneManager.LoadScene("JaydinMainMenuTest");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.ShowPause();

    }

    private void Start()
    {

        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object

        levelComplete = levelCompletePanel.GetComponent<CompleteLevelManager>();

        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }
}
