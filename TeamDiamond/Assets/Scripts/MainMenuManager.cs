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

    public void StartChickLevel3()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinChickLevel3Test");
    }

    public void StartChickLevel4()
    {
        // Load the "Level" scene
        SceneManager.LoadScene("JaydinChickLevel4Test");
    }



}