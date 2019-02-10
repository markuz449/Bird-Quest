using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class LevelMaster : MonoBehaviour {

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject levelCompletePanel;
    public Text numResets;
    public Text timeTaken;
    private static LevelMaster instance;
    private GameMaster gm;
    public Sprite star;

    private Vector3 player1Nest = new Vector3(1.38f, -0.7920535f, 0);
    private Vector3 ChickNest = new Vector3(70.4f, 0f, 0);


    public GameObject[] boxes;
    public Vector3[] boxesStart;
    public GameObject[] logs;
    public Vector3[] logsStart;
    public Image menuChick;
    public Image menuWorm;
    public Image menuReset;


    private GameObject player;
    private GameObject chick;
     

    //private GameObject text1;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;
    //CompleteLevelManager levelComplete;
    public bool checkpointReached;
    public bool hasreset;
    public int resets;

    public bool Level1;
    public bool Level2;


    public bool GetLevel1(){
        return Level1;


    }

    public bool GetLevel2()
    {
        return Level2;


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

    public void UnlockLevel2()
    {

        Level2 = true;
    }

    



    public void UnlockLevel1(){

        Level1 = true;
    }

    public void CompleteTutorial()
    {
        SceneManager.LoadScene("MainMenu");
        ClearReset();
        Time.timeScale = 1f;


        UnlockLevel1();
    }



    public void CompleteLevel1()
    {
        SceneManager.LoadScene("MainMenu");
        ClearReset();
        Time.timeScale = 1f;


        //UnlockLevel2();
    }

    public void LevelFinish()
    {
        Time.timeScale = 0;

        int numresets = GetNumResets();
        numResets.text = "Total Resets: " + numresets.ToString();
        float time = Mathf.Round(Time.timeSinceLevelLoad);
        float timeFirst = Mathf.Floor(time / 60);
        float timeSeconds = time % 60;
        string temp = "";
        if (timeSeconds < 10){

            temp = "0";

        }

        //menuChick.sprite = star;

        timeTaken.text = "Time Taken: " + timeFirst + ":" + temp +  timeSeconds;

        levelCompletePanel.SetActive(true);
    }

    public void ReloadLevel()
    {


        if (logs != null && boxes != null && logsStart != null && boxesStart != null)
        {
            for (int i = 0; i < logs.Length; i++)
            {
                logs[i].transform.position = logsStart[i];
            }
            for (int j = 0; j < boxes.Length; j++)
            {
                boxes[j].transform.position = boxesStart[j];
            }
        }
        player.transform.localPosition = gm.PlayerCoords();
        chick.transform.localPosition = gm.ChickCoords();



        PlayerReset();

    }

    public void RetryLevel()
    {
        checkpointReached = false;
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
        SceneManager.LoadScene("MainMenu");
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

     
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
    }

    void Update()
    {

        if(SceneManager.GetActiveScene().name == "Level1" && hasreset == false && checkpointReached == false){
            gm.lastCheckpointPos = player1Nest;
            gm.chickLastCheckpoint = ChickNest;

        }

        if (logs.Length == 0 || logs[0] == null)
        {
            checkpointReached = false;



    boxes = GameObject.FindGameObjectsWithTag("Box");
            logs = GameObject.FindGameObjectsWithTag("Log");
            boxesStart = new Vector3[boxes.Length];
            logsStart = new Vector3[logs.Length];
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


            //menuChick = GameObject.FindGameObjectWithTag("menuChick").GetComponent<Image>();
            //menuWorm = GameObject.FindGameObjectWithTag("menuWorm").GetComponent<Image>();
            //menuReset = GameObject.FindGameObjectWithTag("menureset").GetComponent<Image>();
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            player = GameObject.FindGameObjectWithTag("Player");
            chick = GameObject.FindGameObjectWithTag("Chick");
            if(timeTaken == null){
                //levelCompletePanel.SetActive(true);

                timeTaken = GameObject.FindGameObjectWithTag("TimeTakenText").GetComponent<Text>();
            }

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


            ReloadLevel();
         

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
