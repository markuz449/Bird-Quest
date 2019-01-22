using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler: MonoBehaviour {

    public float maxSpeed = 6f;
    public bool facingRight = true;


	// Use this for initialization
	void Start () {
		
	}


    // FixedUpdate is called once per frame
    void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if(move > 0 && !facingRight){
            Flip();
        }else if(move < 0 && facingRight){
            Flip();
        }
	}

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
