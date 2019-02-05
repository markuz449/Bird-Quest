using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelMaster : MonoBehaviour {

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject levelCompletePanel;
    public Text numResets;
    private static LevelMaster instance;
    private GameMaster gm;


    private GameObject[] boxes;
    private Vector3[] boxesStart;
    private GameObject[] logs;
    private Vector3[] logsStart;
    private GameObject player;
    private GameObject chick;
     

     public Vector2 lastCheckpointPos;
    //private GameObject text1;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;
    //CompleteLevelManager levelComplete;

    public bool hasreset;
    public int resets;

    public bool Level1;

    public bool GetLevel1(){
        return Level1;


    }



    public void PlayerReset(){
        hasreset = true;
        resets++;

    }



    public int GetNumResets(){

        return resets;

    }

    public void ClearReset(){

        hasreset = false;
        resets = 0;

    }


    public bool GetReset()
    {
        return hasreset;


    }


   


    public void UnlockLevel1(){

        Level1 = true;
    }



    public void CompleteLevel1()
    {
        SceneManager.LoadScene("JaydinMainMenuTest");
        ClearReset();

        UnlockLevel1();
    }

    public void LevelFinish()
    {
        int numresets = GetNumResets();
        numResets.text = "Total Resets: " + numresets.ToString();

        levelCompletePanel.SetActive(true);
    }

    public void ReloadLevel()
    {
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



        PlayerReset();

        // Load the "Level" scene
        //SceneManager.LoadScene(currentSceneName);
    }

    public void RetryLevel()
    {
        ClearReset();

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenuOpen()
    {
        ClearReset();
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinMainMenuTest");
    }

    public void OpenPauseMenu()
    {
        pauseMenu.ShowPause();

    }

    private void Start()
    {
        Level1 = false;
        hasreset = false;
        boxes = GameObject.FindGameObjectsWithTag("Box");
        logs = GameObject.FindGameObjectsWithTag("Log");
        boxesStart = new Vector3[boxes.Length];
        logsStart = new Vector3[logs.Length];

        for (int i = 0; i < logs.Length; i++)
        {
            logsStart[i] = logs[i].transform.position;
        }
        for (int i = 0; i < boxes.Length; i++)
        {
            boxesStart[i] = boxes[i].transform.position;
        }

        //game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object

        //levelComplete = levelCompletePanel.GetComponent<CompleteLevelManager>();

        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        //pauseMenu.Hide();
    }

    void Update()
    {
       
        if (logs.Length == 0)
        {
            boxes = GameObject.FindGameObjectsWithTag("Box");
            logs = GameObject.FindGameObjectsWithTag("Log");
            boxesStart = new Vector3[boxes.Length];
            logsStart = new Vector3[logs.Length];

            for (int i = 0; i < logs.Length; i++)
            {
                logsStart[i] = logs[i].transform.position;
            }
            for (int i = 0; i < boxes.Length; i++)
            {
                boxesStart[i] = boxes[i].transform.position;
            }

        }
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {



            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            player = GameObject.FindGameObjectWithTag("Player");
            chick = GameObject.FindGameObjectWithTag("Chick");


            if (numResets == null)
            {
                numResets = GameObject.FindGameObjectWithTag("Resets").GetComponent<Text>();
            }
            if (levelCompletePanel == null)
            {
                levelCompletePanel = GameObject.FindGameObjectWithTag("CompleteMenu");
                levelCompletePanel.SetActive(false);
            }
            if (pauseMenuPanel == null)
            {
                pauseMenuPanel = GameObject.FindGameObjectWithTag("PauseMenu");
                pauseMenuPanel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // var currentScene = SceneManager.GetActiveScene();
            //var currentSceneName = currentScene.name;

            //lm.PlayerReset();

            ReloadLevel();
            // Load the "Level" scene
            //SceneManager.LoadScene(currentSceneName);

        }
    }





    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {

            Destroy(gameObject);
        }
    }




}
