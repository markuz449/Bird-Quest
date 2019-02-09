using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {

    Vector3 location;
    Vector3 destination;

	// Use this for initialization
	void Start () {

        location = transform.position;
        destination = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

		
	}
	
	// Update is called once per frame
	void Update () {
        location = Vector3.Lerp(location, destination, Time.deltaTime);
        transform.position = location;
	}
}
