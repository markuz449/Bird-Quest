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
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumpDistanceFromGround = 0.5f;
    public float jump = 0.2f;

    private Rigidbody2D body = null;
    //private bool grounded = false;
    private bool facingRight = true;

    // Use this for initialization
    void Start () {
        //Get the reference to rigid body comonent
        body = transform.GetComponent<Rigidbody2D> ();
        Flip();
    }

    // Update is called once per frame
    void FixedUpdate () {

        //grounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

        //Get movement input
        float h = Input.GetAxis("Horizontal");

        if (body != null) {

            if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && IsGrounded()){
                body.velocity = new Vector2(0, jumpPower);
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        canJump = true;
    //    }
    //}

    bool IsGrounded()
    {
        bool final = false;
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0, -jumpDistanceFromGround);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, jumpDistanceFromGround, groundLayer);

        float range = jump + 0.02f;
        if(facingRight){
            range = -jump + 0.02f;
        }

        for (float i = -0.4f + range; i < 0.4f + range; i+= 0.1f){
            position = new Vector2(transform.position.x + i, transform.position.y);
            Debug.DrawRay(position, direction, Color.green);
            hit = Physics2D.Raycast(position, direction, jumpDistanceFromGround, groundLayer);
            if (hit.collider != null)
            {
                final = true;
            }
        }

        if (final)
        {
            return true;
        }
        return false;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
