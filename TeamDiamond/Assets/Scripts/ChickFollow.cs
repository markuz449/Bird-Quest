using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickFollow : MonoBehaviour {

    public float speed = 4f;
    public float jumpSpeed = 5f;
    public float stoppingDistance = 1.1f;

    private Transform target;
    private bool stay = false;
    private bool jump = true;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance && !stay){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            
        }else if(stay){
            transform.position = this.transform.position;
        }
        if(Input.GetKeyDown (KeyCode.Space)){
            stay = !stay;
        }
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.Space))
        {
            stay = !stay;
        }
    }

    // if collided with some wall or block, jump
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // only check lateral collisions
        if (Mathf.Abs(hit.normal.y) < 0.5)
        {
            jump = true; // jump if collided laterally
        }
    }
}
