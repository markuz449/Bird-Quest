using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color loadToColor = Color.white;
    public GameObject day;
    public GameObject night;
    public bool state = true;

    private void Start()
    {
        day.SetActive(false);
        night.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StateChange();
        }
    }

    public void GoFade()
    {
        Initiate.Fade(scene, loadToColor, 1.0f);
    }

    public void StateChange(){
        if (state == true)
        {
            day.SetActive(false);
            night.SetActive(true);
            state = false;
        }
        else
        {
            day.SetActive(true);
            night.SetActive(false);
            state = true;
        }
    }
}
