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

    private GameMaster gm;


    private GameObject[] boxes;
    private Vector3[] boxesStart;
    private GameObject[] logs;
    private Vector3[] logsStart;
    //private GameObject text1;

    private GameObject player;
    private GameObject chick;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;
    //CompleteLevelManager levelComplete;

    public void CompleteLevel1(){
        SceneManager.LoadScene("JaydinMainMenuTest");
        game.ClearReset();

        game.UnlockLevel1();
    }

    public void LevelFinish(){
        int numresets = game.GetNumResets();

        numResets.text = "Total Resets: " + numresets.ToString();


        levelCompletePanel.SetActive(true);
    }

    public void ReloadLevel(){
        //var currentScene = SceneManager.GetActiveScene();
        //var currentSceneName = currentScene.name;
        for (int i = 0; i < logs.Length; i++)
        {
            logs[i].transform.position = logsStart[i];
        }
        for (int j = 0; j < boxes.Length; j++)
        {
            boxes[j].transform.position = boxesStart[j];
        }
        player.transform.localPosition = gm.PlayerCoords();
        chick.transform.localPosition = gm.ChickCoords();


        game.PlayerReset();

        // Load the "Level" scene
        //SceneManager.LoadScene(currentSceneName);
    }

    public void RetryLevel(){
        game.ClearReset();

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenuOpen(){
        game.ClearReset();

        // Load the "Level" scene
        SceneManager.LoadScene("JaydinMainMenuTest");
    }

    public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start(){

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        chick = GameObject.FindGameObjectWithTag("Chick");



        boxes = GameObject.FindGameObjectsWithTag("Box");
        logs = GameObject.FindGameObjectsWithTag("Log");
        boxesStart = new Vector3[boxes.Length];
        logsStart = new Vector3[logs.Length];

        for (int i = 0; i < logs.Length; i++){
            logsStart[i] = logs[i].transform.position;
        }
        for (int i = 0; i < boxes.Length; i++)
        {
            boxesStart[i] = boxes[i].transform.position;
        }


        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object

        //levelComplete = levelCompletePanel.GetComponent<CompleteLevelManager>();

        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        //pauseMenu.Hide();
    }
}
