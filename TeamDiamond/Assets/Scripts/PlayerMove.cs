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
    public float pullSpeed = 0.5f;
    public float jumpPower = 11;
    public LayerMask groundLayer;
    public float jumpRayLength = 0.6f;
    public bool facingRight = true;

    //public variables for pushing box
    public GameObject pushCollider;

    // public Vairables for pulling the box
    public float distance = 0.5f;
    public LayerMask boxMask;

    // private Variables for pulling the box
    private GameObject box;
    private bool connected = false;

    // Other private vairables
    private Rigidbody2D body = null;
    private float jumpOffset = 0.2f;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        //Get the reference to rigid body comonent
        body = transform.GetComponent<Rigidbody2D>();
        if (!facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        //Set start animation
        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");
    }

    // Update is called once per frame
    void FixedUpdate () {

        //Get movement input
        float h = Input.GetAxis("Horizontal");

        int pull = PullBox();

        // Checks for Ridgidbody2D
        if (body != null){

            //Changes animation layer if you are on ground or not
            HandleLayers();

            //Checks to see if you are falling
            if (body.velocity.y < 0){
                anim.SetBool("Land", true);
            }

            // Moves Player. Jump if IsGrounded()
            if (IsGrounded() && (Input.GetKey(KeyCode.UpArrow) ||
                                Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))   
            {
                body.velocity = new Vector2(0, jumpPower);
                anim.SetTrigger("Jump");
                anim.SetBool("pushingBox", false);
                anim.SetBool("pullingBox", false);
                pushCollider.SetActive(false);
            }
            if (pull != 0){
                body.velocity = new Vector2(h * pullSpeed * speed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else{
                body.velocity = new Vector2(h * speed, GetComponent<Rigidbody2D>().velocity.y);
                anim.SetBool("pushingBox", false);
                anim.SetBool("pullingBox", false);
                pushCollider.SetActive(false);
            }
            anim.SetFloat("runSpeed", Mathf.Abs(h));
        }

        // Flips sprite
        if (h > 0 && !facingRight && pull == 0)
        {
            Flip();
        }
        else if (h < 0 && facingRight && pull == 0)
        {
            Flip();
        }
    }

    // Lets the character pull 'box' objects
    int PullBox()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        bool push = true;
        float side;
        float direction;

        if (hit.collider != null && (hit.collider.gameObject.tag == "Box" || hit.collider.gameObject.tag == "Log")){
            pushCollider.SetActive(true);
            box = hit.collider.gameObject;
            side = box.transform.position.x - transform.position.x;
            direction = Input.GetAxis("Horizontal");
            //Setting push/pull animation here - Marcus
            if ((side > 0f && direction > 0f) || (side < 0f && direction < 0f)){
                push = true;
                anim.SetBool("pushingBox", true);
                anim.SetBool("pullingBox", false);
            }
            else{
                push = false;
                anim.SetBool("pushingBox", false);
                anim.SetBool("pullingBox", true);
            }
        }

        // Drops the box if jumping or over an edge
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || !IsGrounded() || push) 
            && connected)
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            connected = false;
            return 0;
        // Attaches the box to the player if not jumping and on the ground
        }else if (hit.collider != null && (hit.collider.gameObject.tag == "Box" || hit.collider.gameObject.tag == "Log") 
                  && IsGrounded() && !push && !connected)
        {
            box = hit.collider.gameObject;
            connected = true;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            return 1;
        }else if(hit.collider != null && (hit.collider.gameObject.tag == "Box" || hit.collider.gameObject.tag == "Log")) {
            return 1;
        }
        return 0;
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
        float final = 0;
        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0, -jumpRayLength);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, jumpRayLength, groundLayer);

        // Adjusts for sprite flip
        float range = jumpOffset;
        if(facingRight){
            range = -jumpOffset;
        }

        // generates rays at players location
        // Player is allowed to jump when at least one ray is touching the groundLayer
        for (float i = -0.3f + range; i < 0.3f + range; i+= 0.1f){
            position = new Vector2(transform.position.x + i, transform.position.y);
            Debug.DrawRay(position, direction, Color.green);
            hit = Physics2D.Raycast(position, direction, jumpRayLength, groundLayer);
            if (hit.collider != null)
            {
                final++;
            }
        }

        if (final > 1){
            //Set's animation settings when on the ground
            anim.ResetTrigger("Jump");
            anim.SetBool("Land", false);
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

    //Marcus code for handling jumping animation
    private void HandleLayers(){
        if (!IsGrounded()){
            anim.SetLayerWeight(1, 1);
        } 
        else {
            anim.SetLayerWeight(1, 0);
        }
    }
}
