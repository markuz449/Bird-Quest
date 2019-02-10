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

    public void CompleteTutorial()
    {
        SceneManager.LoadScene("MainMenu");
        game.ClearReset();
        Time.timeScale = 1f;


        game.UnlockLevel1();
    }



    public void CompleteLevel1()
    {
        SceneManager.LoadScene("MainMenu");
        game.ClearReset();
        Time.timeScale = 1f;


        //game.UnlockLevel2();
    }

    public void LevelFinish(){
        int numresets = game.GetNumResets();

        numResets.text = "Total Resets: " + numresets.ToString();

        //game.menuChick.sprite = star;


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
        game.checkpointReached = false;
        game.levelComplete = false;
        game.collectibleFound = false;


        game.ClearReset();
        Time.timeScale = 1f;

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenuOpen(){
        game.ClearReset();

        // Load the "Level" scene
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start(){

        

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        chick = GameObject.FindGameObjectWithTag("Chick");



        //game.menuChick = GameObject.FindGameObjectWithTag("menuChick").GetComponent<Image>();
        //game.menuWorm = GameObject.FindGameObjectWithTag("menuWorm").GetComponent<Image>();
        //game.menuReset = GameObject.FindGameObjectWithTag("menureset").GetComponent<Image>();



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



        game.menuChick = GameObject.FindGameObjectWithTag("menuChick");
        game.menuWorm = GameObject.FindGameObjectWithTag("menuWorm");
        game.menuReset = GameObject.FindGameObjectWithTag("menuReset");
        game.menuChickStar = GameObject.FindGameObjectWithTag("menuChickStar");
        game.menuWormStar = GameObject.FindGameObjectWithTag("menuWormStar");
        game.menuResetStar = GameObject.FindGameObjectWithTag("menuResetStar");


        game.levelComplete = false;
        game.collectibleFound = false;


        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object

        //levelComplete = levelCompletePanel.GetComponent<CompleteLevelManager>();

        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        //pauseMenu.Hide();
    }
}
