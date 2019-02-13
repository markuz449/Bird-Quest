using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToNight : MonoBehaviour
{

    Vector3 startPosition;
    Vector3 location;
    Vector3 destination;

    //StateChangeTrigger stopper = new StateChangeTrigger();


    // Use this for initialization
    void Start()
    {

        //startPosition = transform.position;
        //location = startPosition;
        //destination = new Vector3(transform.position.x, transform.position.y - 3.25f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        //location = Vector3.Lerp(location, destination, Time.deltaTime);
        //transform.position = location;

        //if (location == destination)
        //{
        //    transform.position = startPosition;
        //}
    }
}
