﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeTrigger : MonoBehaviour {

    //name of the gameobject you want to transition between
    public GameObject day;
    public GameObject night;
    public DayNight stateControl;
    Flower[] flower;
    public bool daytime;

    public void OnTriggerEnter2D(Collider2D collision){
        stateControl.StateChange(daytime);

        if (daytime == true){
            foreach (Flower bloom in flower){
                bloom.Bloom();
            }
        } else {
            foreach (Flower bloom in flower){
                bloom.Debloom();
            }
        }
        // maybe don't destroy them??
        //Destroy(gameObject);
    }

    private void Start(){
        flower = day.GetComponentsInChildren<Flower>();
    }
}
