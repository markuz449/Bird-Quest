using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    //name of the gameobject you want to transition between
    public GameObject day;
    public GameObject night;
    //public float stateTime; 
    FadeObjectInOut fday;
    FadeObjectInOut fnight;
    public bool dayTime = true;

    //FlowerGrowShrink flower;

    //jack code
    //public GameObject[] nightObjects = GameObject.FindGameObjectsWithTag("Night");
    //public GameObject[] dayObjects = GameObject.FindGameObjectsWithTag("Day"); 

    private void Start(){
        fday = day.AddComponent<FadeObjectInOut>();
        fnight = day.AddComponent<FadeObjectInOut>();
        fday.FadeIn();
        //StartCoroutine(DayTime());
        //flower = new FlowerGrowShrink();
    }


    public bool GetState() {
        return dayTime;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.N))
    //    {
    //        StateChange(!dayTime);
    //    }
    //}

    public void StateChange(bool currentState){
        if (currentState != dayTime){
            if (dayTime == true){
                //flower.Change();
                dayTime = false;
                fday.FadeOut(0.8f);
                night.SetActive(true);
                SetAllCollidersStatus(day, false);
            }
            else {
                //flower.Change();
                dayTime = true;
                fday.FadeIn(0.6f);
                night.SetActive(false);
                SetAllCollidersStatus(day, true);
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
