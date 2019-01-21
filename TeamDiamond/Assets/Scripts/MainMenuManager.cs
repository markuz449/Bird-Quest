using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void StartNestLevel()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinNestLevelTest");
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

   



}