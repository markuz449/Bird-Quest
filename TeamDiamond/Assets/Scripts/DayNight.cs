using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    //name of the scene you want to load
    public GameObject day;
    public GameObject night;
    //public float stateTime; 
    FadeObjectInOut fday;
    FadeObjectInOut fnight;
    public bool dayTime = true;

    //jack code
    //public GameObject[] nightObjects = GameObject.FindGameObjectsWithTag("Night");
    //public GameObject[] dayObjects = GameObject.FindGameObjectsWithTag("Day");

    private void Start(){
        fday = day.AddComponent<FadeObjectInOut>();
        fnight = day.AddComponent<FadeObjectInOut>();
        fday.FadeIn();
        //StartCoroutine(DayTime());
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.N))
    //    {
    //        StateChange(!dayTime);
    //    }
    //}

    public void StateChange(bool currentState){
        if (currentState != dayTime)
        {
            if (dayTime == true)
            {

                //foreach (GameObject d in dayObjects) {
                //    d.transform.Translate(Vector3.down * Time.deltaTime);
                //}

                fday.FadeOut(0.8f);
                night.SetActive(true);
                SetAllCollidersStatus(day, false);
                dayTime = false;
            }
            else
            {
                ////jack adding code in here 
                //foreach (GameObject n in nightObjects) {
                //    n.transform.Translate(Vector3.up * Time.deltaTime);
                //}
                ////jack stopped adding code here
                fday.FadeIn(0.6f);
                night.SetActive(false);
                SetAllCollidersStatus(day, true);
                dayTime = true;
            }
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
