using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConveyer : MonoBehaviour {

    public Transform chick;
    private Transform target;
    private SurfaceEffector2D se2d;

    // Use this for initialization
    void Start () {
        se2d = GetComponent<SurfaceEffector2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(chick.position.x > target.position.x){
            se2d.speed = -1;
        }else{
            se2d.speed = 1;
        }
	}
}
