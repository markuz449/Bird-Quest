using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeTrigger : MonoBehaviour {

    //name of the gameobject you want to transition between
    public GameObject day;
    public DayNight stateControl;
    Flower[] flower;
    public GameObject[] flowerGrowShrinks;
    public bool daytime;
    public bool movingPlatform = false;

    public Vector3 currentPosition;
    public Vector3 destination;

    public static bool quit;
    public float wait;
    public bool destroy = false;

    public void OnTriggerEnter2D(Collider2D collision){
        //if (movingPlatform){
        stateControl.StateChange(daytime);
        //System.Threading.Thread.Sleep(1000);

        if (daytime == true)
        {
            foreach (Flower bloom in flower)
            {
                Debug.Log("blooming");
                bloom.Bloom();
            }
        }
        else
        {
            foreach (Flower bloom in flower)
            {
                Debug.Log("DE-blooming");
                bloom.Debloom();
            }
        }

        foreach (GameObject flowergrow in flowerGrowShrinks){
                if (daytime){
                    if (flowergrow.GetComponent<ChangeToNight>() != null){
                        Destroy(flowergrow.GetComponent<ChangeToNight>());

                    Debug.Log("test");
                    }

                    if (flowergrow.GetComponent<ChangeToDay>() == null){
                        flowergrow.AddComponent<ChangeToDay>();
                    Debug.Log("test");
                }
                    //flowergrow.GetComponent<ChangeToNight>().enabled = false;
                    //flowergrow.GetComponent<ChangeToDay>().enabled = true;
                }
                else {
                    if (flowergrow.GetComponent<ChangeToDay>() != null){
                        Destroy(flowergrow.GetComponent<ChangeToDay>());
                    Debug.Log("test");
                }

                    if (flowergrow.GetComponent<ChangeToNight>() == null){
                        flowergrow.AddComponent<ChangeToNight>();
                    Debug.Log("test");
                }
                    //flowergrow.GetComponent<ChangeToDay>().enabled = false;
                    //flowergrow.GetComponent<ChangeToNight>().enabled = true;
                }
            }

        if(destroy == true){
            Destroy(gameObject);
        }
        //}
    }

    private void Awake(){
        flower = day.GetComponentsInChildren<Flower>();
        flowerGrowShrinks = GameObject.FindGameObjectsWithTag("Items");
    }
}
