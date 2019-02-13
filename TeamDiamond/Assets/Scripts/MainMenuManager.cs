using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour{

    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject level1Icon;
    public GameObject level2Icon;
    public GameObject level3Icon;
    public GameObject level4Icon;

    public GameObject Tutorial;
    public GameObject level1Background;
    public GameObject level2Background;
    public GameObject level3Background;

    private LevelMaster game;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;

    public bool level1;
    public bool level2;
    public bool level3;
    public bool level4;



    public void StartNestLevel(){
        // Load the "Level" scene
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenuOpen(){
        // Load the "Level" scene
        SceneManager.LoadScene("MainMenu");
    }

    public void StartChickLevel1(){
        // Load the "Level" scene
        SceneManager.LoadScene("Level1");

    }

    public void StartChickLevel2(){
        // Load the "Level" scene

        SceneManager.LoadScene("Level2");
    }

    public void StartChickLevel3(){
        // Load the "Level" scene

        SceneManager.LoadScene("Level3");
    }

    public void StartChickLevel4()
    {
        // Load the "Level" scene

        SceneManager.LoadScene("Level4");
    }


    public void UnlockLevel1(){
        level1 = game.GetLevel1();
    }

    public void UnlockLevel3() {
        level3 = game.GetLevel3();
    }

    public void UnlockLevel4()
    {
        level4 = game.GetLevel4();
    }

    public void UnlockLevel2(){
        level2 = game.GetLevel2();
    }

    public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start(){
        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    private void Update(){
        level1 = game.GetLevel1();
        level2 = game.GetLevel2();
        level3 = game.GetLevel3();
        level4 = game.GetLevel4();


        if (level1){
            level1Icon.SetActive(true);
            level1Background.SetActive(true);
            Tutorial.SetActive(false);
        } 
        else if(!level1){
            level1Icon.SetActive(false);
        }

        if(level2){
            level2Icon.SetActive(true);
            level2Background.SetActive(true);
            level1Background.SetActive(false);
        } 
        else if (!level2){
            level2Icon.SetActive(false);
        }

        if (level3){
            level3Icon.SetActive(true);
            level3Background.SetActive(true);
            level2Background.SetActive(false);
        } 
        else if (!level3){
            level3Icon.SetActive(false);
        }

        if (level4)
        {
            level4Icon.SetActive(true);
            //level4Background.SetActive(true);
            //level3Background.SetActive(false);
        }
        else if (!level3)
        {
            level4Icon.SetActive(false);
        }


    }
}