/*
    Created by: Lech Szymanski
                lechszym@cs.otago.ac.nz
                Jan 19, 2016            
*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    public float speed = 2;
    public float jumpPower = 5;

    private Rigidbody2D body = null;
    private bool canJump = false;

    // Use this for initialization
    void Start()
    {
        //Get the reference to rigid body comonent
        body = transform.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If not in collisions with something, and not moving up and down then not airborne
        float verticalSpeed = Mathf.Abs(body.velocity.y);
        if (verticalSpeed < 0.001)
        {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //If not in collision with something, then airborne
        canJump = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //Get movement input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Only going up is allowed when jumping and
        //only when not airborne
        if (canJump && v > 0)
        {
            v = jumpPower;
        }
        else
        {
            v = 0;
        }

        if (body != null)
        {
            //Add movement forces to the body
            body.AddForce(new Vector2(0, v), ForceMode2D.Impulse);
            body.AddForce(new Vector2(h * 5, 0));
        }
    }
}
