using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color loadToColor = Color.white;
    public GameObject background;
    public GameObject backgroundNight;
    public GameObject platforms;
    public GameObject platformsNight;
    public bool state = true;

    /*private void Start()
    {
        background.SetActive(true);
        backgroundNight.SetActive(false);
        platforms.SetActive(true);
        platformsNight.SetActive(false);
    }*/

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (state == true)
            {
                background.SetActive(false);
                backgroundNight.SetActive(true);
                platforms.SetActive(false);
                platformsNight.SetActive(true);
                state = false;
            } else{
                background.SetActive(true);
                backgroundNight.SetActive(false);
                platforms.SetActive(true);
                platformsNight.SetActive(false);
                state = true;
            }
        }
    }

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }
}
