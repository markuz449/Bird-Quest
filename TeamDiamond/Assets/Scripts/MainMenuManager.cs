using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   



    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject level1Icon;
    public GameObject level2Icon;

    private LevelMaster game;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;

    public  bool level1;

    public bool level2;







    public void StartNestLevel()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenuOpen()
    {

        // Load the "Level" scene
        SceneManager.LoadScene("MainMenu");
    }

    public void StartChickLevel1()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("Level1");

    }

    public void StartChickLevel2()
    {
        // Load the "Level" scene

        SceneManager.LoadScene("Level2");
    }


    public  void UnlockLevel1(){
        level1 = game.GetLevel1();




}

    public void UnlockLevel2()
    {
        level2 = game.GetLevel2();




    }

    public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();

        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    private void Update()
    {
        level1 = game.GetLevel1();
        level2 = game.GetLevel2();

        if (level1){

            level1Icon.SetActive(true);
        } else if(!level1){

            level1Icon.SetActive(false);
        }

        if(level2){
            level2Icon.SetActive(true);

        }
        else if (!level2)
        {
            level2Icon.SetActive(false);

        }
    }


}