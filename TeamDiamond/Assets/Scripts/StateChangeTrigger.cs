using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeTrigger : MonoBehaviour {

    public DayNight stateControl;
    public bool daytime = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (daytime)
        {
            stateControl.StateChange(false);
        }
        else
        {


            stateControl.StateChange(daytime);
        }
            //if (daytime)
        //{
        //    stateControl.StateChange(false);
        //}
        //else
        //{
        //    stateControl.StateChange(daytime);
        //    // maybe don't destroy them??
        //    //Destroy(gameObject);
        //}
    }
}
