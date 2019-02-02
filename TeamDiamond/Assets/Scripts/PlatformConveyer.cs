using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SurfaceEffector2D))]
public class PlatformConveyer : MonoBehaviour {

    public Transform chick;
    private Transform target;
    private SurfaceEffector2D se2d;

    // Use this for initialization
    void Start () {
        se2d = GetComponent<SurfaceEffector2D>();
        if (target != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target != null)
        {
            if (chick.position.x > target.position.x)
            {
                se2d.speed = -1;
            }
            else
            {
                se2d.speed = 1;
            }
        }
	}
}
