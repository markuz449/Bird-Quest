using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   



    // Reference to UI panel that is our pause menu
    public GameObject pauseMenuPanel;
    public GameObject level1Icon;

    // Reference to panel's script object 
    PauseMenuManager pauseMenu;

    public  bool level1;





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

   


public  void UnlockLevel1(){

        level1 = true;

}

public void OpenPauseMenu(){
        pauseMenu.ShowPause();

    }

    private void Start()
    {
        level1 = false;
        // Initialise the reference to the script object, which is a
        // component of the pause menu panel game object
        pauseMenu = pauseMenuPanel.GetComponent<PauseMenuManager>();
        pauseMenu.Hide();
    }

    private void Update()
    {
        if (level1){

            level1Icon.SetActive(true);
        }
    }


}