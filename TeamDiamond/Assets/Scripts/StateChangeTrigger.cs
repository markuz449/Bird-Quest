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

    public void OnTriggerEnter2D(Collider2D collision){

        foreach (GameObject flowergrow in flowerGrowShrinks){
            flowergrow.transform.position += new Vector3(0, 2, 0);
        }
        
        stateControl.StateChange(daytime);
        if (daytime == true){
            foreach (Flower bloom in flower){
                bloom.Bloom();
            }
        } else{
            foreach (Flower bloom in flower){
                bloom.Debloom();
            }
        }
        // maybe don't destroy them??
        //Destroy(gameObject);
    }

    private void Awake(){
        flower = day.GetComponentsInChildren<Flower>();
        flowerGrowShrinks = GameObject.FindGameObjectsWithTag("Items");
    }
}
