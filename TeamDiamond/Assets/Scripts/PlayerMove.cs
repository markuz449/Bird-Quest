/*
    Created by: Lech Szymanski
                lechszym@cs.otago.ac.nz
                Jan 19, 2016            
*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 2;
    public float jumpPower = 5;
    public bool facingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D body = null;
    private bool canJump = false;
    private bool grounded = false;

    // Use this for initialization
    void Start () {
        //Get the reference to rigid body comonent
        body = transform.GetComponent<Rigidbody2D> ();
        canJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            canJump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

        //Get movement input
        float h = Input.GetAxis("Horizontal");

        if (body != null) {
            //Add movement forces to the body
            if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canJump){
                body.velocity = new Vector2(0, jumpPower);
                canJump = false;
            }


            body.velocity = new Vector2(h * speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
