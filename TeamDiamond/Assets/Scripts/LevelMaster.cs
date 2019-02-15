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

    // Level1 reset parameters
    private Vector3 player1Nest = new Vector3(1.38f, -0.49f, 0);
    private Vector3 ChickNest = new Vector3(70.4f, 0f, 0);

    //Level2 reset paramaters
    private Vector3 player1Nest2 = new Vector3(-13.11f, -28.25f, 0);
    private Vector3 ChickNest2 = new Vector3(6.35f, -28.34f, 0);

    //Level2 reset paramaters
    private Vector3 player1Nest3 = new Vector3(-5.7f, -1.94f, 0);
    private Vector3 ChickNest3 = new Vector3(57.57903f, 4.921473f, 0);

    //Level2 reset paramaters
    private Vector3 player1Nest4 = new Vector3(-14.53f, -0.82f, 0);
    private Vector3 ChickNest4 = new Vector3(38.51f, -0.79f, 0);

    public bool levelComplete;
    public GameObject[] boxes;
    public Vector3[] boxesStart;
    public GameObject[] logs;
    public Vector3[] logsStart;

    public GameObject menuChickStar;
    public GameObject menuWormStar;
    public GameObject menuResetStar;

    public GameObject muteButton;
    public GameObject soundButton;


    public bool collectibleFound;

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
    public bool Level3;
    public bool Level4;

    public bool mute;


    public bool GetLevel1(){
        return Level1;
    }

    public bool GetLevel2(){
        return Level2;
    }

    public bool GetLevel3(){
        return Level3;
    }

    public bool GetLevel4(){
        return Level4;
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

    public bool GetReset(){
        return hasreset;
    }

    public void UnlockLevel2(){
        Level2 = true;
    }

    public void UnlockLevel3(){
        Level3 = true;
    }

    public void UnlockLevel4(){
        Level4 = true;
    }

    public void UnlockLevel1(){
        Level1 = true;
    }




    public void CompleteLevel(){

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            SceneManager.LoadScene("EndScreen");
            ClearReset();
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            ClearReset();
            Time.timeScale = 1f;
        }

    }

    public void LevelFinish(){
        levelComplete = true;
        //menuChick.SetActive(false);
        menuChickStar.SetActive(true);

        Time.timeScale = 0;

        int numresets = GetNumResets();

        if (numresets ==0)
        {
            menuResetStar.SetActive(true);
        }

        if (collectibleFound){
            menuWormStar.SetActive(true);

        }
        numResets.text = "Total Resets: " + numresets.ToString();
        float time = Mathf.Round(Time.timeSinceLevelLoad);
        float timeFirst = Mathf.Floor(time / 60);
        float timeSeconds = time % 60;
        string temp = "";
        if (timeSeconds < 10){
            temp = "0";
        }

        timeTaken.text = "Time Taken: " + timeFirst + ":" + temp +  timeSeconds;

        levelCompletePanel.SetActive(true);

        if(SceneManager.GetActiveScene().name == "Tutorial"){
            UnlockLevel1();

        }
        else if (SceneManager.GetActiveScene().name == "Level1"){
            UnlockLevel2();
        }
        else if (SceneManager.GetActiveScene().name == "Level2"){
            UnlockLevel3();
        }

        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            UnlockLevel4();
        }
    }

    public void ReloadLevel(){
        if (logs != null && boxes != null && logsStart != null && boxesStart != null){
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

    public void RetryLevel(){
        collectibleFound = false;

        levelComplete = false;

        checkpointReached = false;
        ClearReset();

        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;

        // Load the "Level" scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenuOpen(){
        ClearReset();
        // Load the "Level" scene
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start(){
        Level1 = false;
        Level2 = false;
        Level3 = false;
        Level4 = false;

        mute = false;

        muteButton = GameObject.FindGameObjectWithTag("MuteButton");
        soundButton = GameObject.FindGameObjectWithTag("SoundButton");


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

    void Update(){

        if (muteButton == null || soundButton == null)
        {
            muteButton = GameObject.FindGameObjectWithTag("MuteButton");
            soundButton = GameObject.FindGameObjectWithTag("SoundButton");

        }
        if (!mute && (SceneManager.GetActiveScene().name != "StartScreen") && (SceneManager.GetActiveScene().name != "EndScreen"))
        {
            soundButton.SetActive(true);
            muteButton.SetActive(false);


        }
        else if (mute && (SceneManager.GetActiveScene().name != "StartScreen") && (SceneManager.GetActiveScene().name != "EndScreen"))
        {

            soundButton.SetActive(false);
            muteButton.SetActive(true);


        }

        if (SceneManager.GetActiveScene().name == "MainMenu"){
            checkpointReached = false;
        }

        float time = Mathf.Round(Time.timeSinceLevelLoad);

        if (time < 2){



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

        if((logs.Length != 0 && logs[0] == null) || (boxes.Length != 0 && boxes[0] == null)){
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

        if (GameObject.FindGameObjectWithTag("Player") != null){

            if (menuWormStar != null && levelComplete != true && time <=10){
                menuWormStar.SetActive(false);
                menuChickStar.SetActive(false);
                menuResetStar.SetActive(false);
            } 
            else if (menuChickStar == null) {
                //menuChick = GameObject.FindGameObjectWithTag("menuChick").GetComponent<GameObject>();
                //menuWorm = GameObject.FindGameObjectWithTag("menuWorm").GetComponent<GameObject>();
                //menuReset = GameObject.FindGameObjectWithTag("menuReset").GetComponent<GameObject>();
                menuChickStar = GameObject.FindGameObjectWithTag("menuChickStar").GetComponent<GameObject>();
                menuWormStar = GameObject.FindGameObjectWithTag("menuWormStar").GetComponent<GameObject>();
                menuResetStar = GameObject.FindGameObjectWithTag("menuResetStar").GetComponent<GameObject>();

            }

            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            player = GameObject.FindGameObjectWithTag("Player");
            chick = GameObject.FindGameObjectWithTag("Chick");

            if (SceneManager.GetActiveScene().name == "Level1" && hasreset == false && checkpointReached == false)
            {
                gm.lastCheckpointPos = player1Nest;
                gm.chickLastCheckpoint = ChickNest;

            }
            else if (SceneManager.GetActiveScene().name == "Level2" && hasreset == false && checkpointReached == false)
            {
                gm.lastCheckpointPos = player1Nest2;
                gm.chickLastCheckpoint = ChickNest2;
            }
            else if (SceneManager.GetActiveScene().name == "Level3" && hasreset == false && checkpointReached == false)
            {
                gm.lastCheckpointPos = player1Nest3;
                gm.chickLastCheckpoint = ChickNest3;
            }
            else if (SceneManager.GetActiveScene().name == "Level4" && hasreset == false && checkpointReached == false)
            {
                gm.lastCheckpointPos = player1Nest4;
                gm.chickLastCheckpoint = ChickNest4;
            }

            if (timeTaken == null){
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

    private void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else{
            Destroy(gameObject);
        }
    }

}
