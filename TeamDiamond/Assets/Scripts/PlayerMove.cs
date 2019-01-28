/*
    Created by: Lech Szymanski
                lechszym@cs.otago.ac.nz
                Jan 19, 2016            
*/

using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    // Vairables controlling speed and jumping
    public float speed = 6;
    public float jumpPower = 11;
    public LayerMask groundLayer;
    public float jumpRayLength = 0.6f;
    public float jumpOffset = 0.2f;

    // public Vairables for pulling the box
    public float distance = 0.5f;
    public LayerMask boxMask;

    // private Variables for pulling the box
    private GameObject box;
    private bool connected = false;

    // Other private vairables
    private Rigidbody2D body = null;
    private bool facingRight = true;

    // Use this for initialization
    void Start () {
        //Get the reference to rigid body comonent
        body = transform.GetComponent<Rigidbody2D> ();
        Flip();
    }

    // Update is called once per frame
    void FixedUpdate () {

        //Get movement input
        float h = Input.GetAxis("Horizontal");

        bool pull = PullBox();

        // Checks for Ridgidbody2D
        if (body != null) {

            // Moves Player. Jump if IsGrounded()
            if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && IsGrounded() && !pull){
                body.velocity = new Vector2(0, jumpPower);
            }
            if(pull){
                body.velocity = new Vector2(h * 0.5f * speed, GetComponent<Rigidbody2D>().velocity.y);
            }else{
                body.velocity = new Vector2(h * speed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        // Flips sprite
        if (h > 0 && !facingRight && !pull)
        {
            Flip();
        }
        else if (h < 0 && facingRight && !pull)
        {
            Flip();
        }
    }

    // Lets the character pull 'box' objects
    bool PullBox(){
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (Input.GetKeyDown(KeyCode.Space) && hit.collider != null && hit.collider.gameObject.tag == "Box")
        {

            box = hit.collider.gameObject;
            connected = true;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            return true;

        }else if (Input.GetKeyUp(KeyCode.Space) && connected) // hit.collider != null && hit.collider.gameObject.tag == "Box")
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            connected = false;
            return false;
        }else if(connected){
            return true;
        }
        return false;
    }

    // Draws line 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

    // Jump function. Lets the Player jump good
    bool IsGrounded()
    {
        // Setting variables for use outside of the for loop
        bool final = false;
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0, -jumpRayLength);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, jumpRayLength, groundLayer);

        // Adjusts for sprite flip
        float range = jumpOffset + 0.02f;
        if(facingRight){
            range = -jumpOffset + 0.02f;
        }

        // generates rays at players location
        // Player is allowed to jump when at least one ray is touching the groundLayer
        for (float i = -0.4f + range; i < 0.4f + range; i+= 0.1f){
            position = new Vector2(transform.position.x + i, transform.position.y);
            Debug.DrawRay(position, direction, Color.green);
            hit = Physics2D.Raycast(position, direction, jumpRayLength, groundLayer);
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

    // Flips the Player's sprtie
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
