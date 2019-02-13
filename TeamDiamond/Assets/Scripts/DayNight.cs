using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    //name of the gameobject you want to transition between
    public GameObject day;
    public GameObject night;
    public GameObject cameraNight;
    public AudioSource dayBGM;
    public AudioSource nightBGM;
    //public float stateTime; 
    FadeObjectInOut fday;
    FadeObjectInOut fnight;
    public bool dayTime = true;

    public GameObject[] flower_elevator;

    public static bool flag = false;

    //FlowerGrowShrink flower;

    //public GameObject[] nightObjects = GameObject.FindGameObjectsWithTag("Night");
    //public GameObject[] dayObjects = GameObject.FindGameObjectsWithTag("Day"); 

    private void Start(){
        fday = day.AddComponent<FadeObjectInOut>();
        fnight = day.AddComponent<FadeObjectInOut>();
        fday.FadeIn();
        dayBGM.Play();
        nightBGM.Stop();
        //flower = new FlowerGrowShrink();
    }


    public bool GetState() {
        return dayTime;
    }

    public void StateChange(bool currentState){
        if (currentState != dayTime){
            if (dayTime == true){
                if (flower_elevator != null){
                    foreach (GameObject flower in flower_elevator){
                        if (flower.GetComponent<ChangeToDay>() != null){
                            Destroy(flower.GetComponent<ChangeToDay>());
                        }
                        if (flower.GetComponent<ChangeToNight>() == null){
                            flower.AddComponent<ChangeToNight>();
                        }
                    }
                }

                //flower.Change();
                dayTime = false;
                fday.FadeOut(0.8f);
                night.SetActive(true);
                cameraNight.SetActive(true);
                SetAllCollidersStatus(day, false);
                dayBGM.Stop();
                nightBGM.Play();
            }
            else{
                foreach (GameObject flower in flower_elevator){
                    if (flower.GetComponent<ChangeToNight>() != null){
                        Destroy(flower.GetComponent<ChangeToNight>());
                    }
                    if (flower.GetComponent<ChangeToDay>() == null){
                        flower.AddComponent<ChangeToDay>();
                    }
                }

                //System.Threading.Thread.Sleep(2000);

                //flower.Change();
                dayTime = true;
                fday.FadeIn(0.6f);
                night.SetActive(false);
                cameraNight.SetActive(false);
                SetAllCollidersStatus(day, true);
                dayBGM.Play();
                nightBGM.Stop();
            }
        }
    }

    public void SetAllCollidersStatus(GameObject state, bool active){
        Collider2D[] col = state.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D c in col){
            c.enabled = active;
        }
    }
}
