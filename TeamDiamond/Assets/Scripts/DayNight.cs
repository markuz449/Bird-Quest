using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    //name of the scene you want to load
    public string scene;
	public Color loadToColor = Color.white;
    public GameObject day;
    public GameObject night;
    //public float stateTime; 
    FadeObjectInOut fday;
    FadeObjectInOut fnight;
    public bool state = true;

    private void Start(){
        fday = day.AddComponent<FadeObjectInOut>();
        fnight = day.AddComponent<FadeObjectInOut>();
        fday.FadeIn();
        //StartCoroutine(DayTime());
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
            fday.FadeOut(0.8f);
            night.SetActive(true);
            SetAllCollidersStatus(day, false);
            state = false;
        }
        else {
            fday.FadeIn(0.6f);
            night.SetActive(false);
            SetAllCollidersStatus(day, true);
            state = true;
        }
    }

    public void SetAllCollidersStatus(GameObject state, bool active){
        Collider2D[] col = state.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D c in col){
            c.enabled = active;
        }
    }

    //IEnumerator DayTime()
    //{
    //    StateChange();
    //    yield return new WaitForSecondsRealtime(stateTime);
    //    StateChange();
    //    yield return new WaitForSecondsRealtime(stateTime);
    //    StartCoroutine(DayTime());
    //}
}
