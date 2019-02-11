﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    private GameObject[] objects;

	// Use this for initialization
	void Start () {
        if(GameObject.FindGameObjectWithTag("Chick") != null){
            objects = GameObject.FindGameObjectsWithTag("Chick");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (objects != null)
        {
            for (int i = 0; i < objects.Length; i++){
                Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), objects[i].GetComponent<Collider2D>());
            }
        }
	}

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Chick") != null)
        {
            objects = GameObject.FindGameObjectsWithTag("Chick");
        }
    }
}
