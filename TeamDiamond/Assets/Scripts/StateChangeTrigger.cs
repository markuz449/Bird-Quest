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

    public Vector3 currentPosition;
    public Vector3 destination;

    public static bool quit;

    public float wait;




   

    public void OnTriggerEnter2D(Collider2D collision)
    {

        foreach (GameObject flowergrow in flowerGrowShrinks)
        {
            if (daytime)
            {

 
                flowergrow.GetComponent<ChangeToNight>().enabled = false;
                flowergrow.GetComponent<ChangeToDay>().enabled = true;
                Debug.Log("test");
                //flowergrow.GetComponent<ChangeToDay>().enabled = false;

            }
            else
            {

                flowergrow.GetComponent<ChangeToDay>().enabled = false;
                flowergrow.GetComponent<ChangeToNight>().enabled = true;
                Debug.Log("test");
                //flowergrow.GetComponent<ChangeToNight>().enabled = false;
            }
        }

        stateControl.StateChange(daytime);



        //if (daytime == true){
        //    foreach (Flower bloom in flower){
        //        bloom.Bloom();
        //    }
        //} else{
        //    foreach (Flower bloom in flower){
        //        bloom.Debloom();
        //    }
        //}

    }


    private void Awake(){
        flower = day.GetComponentsInChildren<Flower>();
        flowerGrowShrinks = GameObject.FindGameObjectsWithTag("Items");
    }
}
