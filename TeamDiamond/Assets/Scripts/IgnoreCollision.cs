using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    public GameObject object1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (object1 != null)
        {
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), object1.GetComponent<Collider2D>());
        }
	}
}
