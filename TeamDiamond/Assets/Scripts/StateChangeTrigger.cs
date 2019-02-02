using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeTrigger : MonoBehaviour {

    public DayNight stateControl;
    public bool daytime = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        stateControl.StateChange(daytime);
        Destroy(gameObject);
    }
}
