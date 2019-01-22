using UnityEngine;

public class DemoScript : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color loadToColor = Color.white;
    public GameObject day;
    public GameObject night;
    FadeObjectInOut fday;
    FadeObjectInOut fnight;
    //public FadeDay day = new FadeDay();
    //public FadeNight night = new FadeNight();
    public bool state = true;

    private void Start()
    {
        //    day.SetActive(false);
        //    night.SetActive(true);
        fday = day.AddComponent<FadeObjectInOut>();
        fnight = day.AddComponent<FadeObjectInOut>();
        fday.FadeIn();
        //fnight.FadeOut();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StateChange();
        }
    }

    public void StateChange(){
        if (state == true)
        {
            fday.FadeOut();
            //SetAllCollidersStatus(day, false);

            //night.SetActive(true);
            //fnight.FadeIn();

            state = false;
        }
        else
        {
            fday.FadeIn();
            //fnight.FadeOut();
            //night.SetActive(false);

            //day.SetActive(true);

            state = true;
        }
    }

    public void SetAllCollidersStatus(GameObject state, bool active){
        foreach (Collider c in GetComponentsInChildren<Collider>()){
            c.enabled = active;
        }
    }
}
