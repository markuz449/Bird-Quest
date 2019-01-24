using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBox : MonoBehaviour {

    public float speed = 5f;
    public bool pull = false;
    public float distanceX = 1f;
    public float distanceY = 0.5f;

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Mathf.Abs(transform.position.x - target.position.x) < distanceX && Mathf.Abs(transform.position.y - target.position.y) < distanceY){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }

    }
}
