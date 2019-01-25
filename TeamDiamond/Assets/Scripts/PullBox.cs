﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBox : MonoBehaviour 
{

    public float distance = 0.3f;
    public LayerMask boxMask;

    private GameObject box;
    private bool connected = false;

	// Use this for initialization
	void Start () 
    {
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null && hit.collider.gameObject.tag == "Box")
        {

            box = hit.collider.gameObject;
            connected = true;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

        }
        else if (Input.GetKeyUp(KeyCode.Space) && connected == true) // hit.collider != null && hit.collider.gameObject.tag == "Box")
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            connected = false;
        }
   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

}
