using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToDay : MonoBehaviour {

    Vector3 startPosition;
    Vector3 location;
    Vector3 destination;

    //public DayNight dayNight = new DayNight();

    //StateChangeTrigger stopper = new StateChangeTrigger();


    // Use this for initialization
    void Start () {

        startPosition = transform.position;
        location = startPosition;
        destination = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {

        location = Vector3.Lerp(location, destination, Time.deltaTime);
        transform.position = location;

        if (location.y > destination.y * 0.9f) {
            transform.position = startPosition;
            DayNight.flag = true;
        }		
	}

}
