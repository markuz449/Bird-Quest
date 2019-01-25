using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(FixedJoint2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Box : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sortingLayerName = "Items";

        GetComponent<Rigidbody2D>().mass = 5;
        GetComponent<Rigidbody2D>().gravityScale = 3;

        GetComponent<FixedJoint2D>().enabled = false;
        transform.tag = "Box";
        gameObject.layer = 8;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
