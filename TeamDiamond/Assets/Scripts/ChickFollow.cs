﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickFollow : MonoBehaviour
{

    public float speed = 5f;

    public float jumpSpeed = 5f;
    public float stoppingHeight = 2.5f;

    public float speedUpDistance = 3f;
    public float slowingDistance = 1f;
    public float stoppingDistance = 0.4f;
    public float tooFar = 8f;

    public float raylength = 1f;
    public LayerMask groundLayer;

    public float stayButtonDistance = 5f;

    private bool facingRight = true;
    private Transform target;
    private bool stay = false;
   

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        float xDistance = Mathf.Abs(transform.position.x - target.position.x);
        float yDistance = Mathf.Abs(transform.position.y - target.position.y);

        Move(xDistance, yDistance);

        // Toggle sitting for the chick
        if (Vector2.Distance(transform.position, target.position) < stayButtonDistance && Input.GetKeyDown(KeyCode.E))
        {
            stay = !stay;
        }
        // Flip the chicks sprite if close to the Mother Bird
        if (xDistance < tooFar && yDistance < stoppingHeight)
        {
            if (target.position.x > transform.position.x && !facingRight)
            {
                Flip();
            }
            else if (target.position.x < transform.position.x && facingRight)
            {
                Flip();
            }
        }

    }

    // Detects a ledge and makes the chick stop moving
    private bool Ledge(){
        float count = 0;

        Vector2 position = transform.position;
        Vector2 direction = new Vector2(0, -raylength);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, raylength, groundLayer);

        float range = -0.1f;
        if(facingRight){
            range = 0.1f;
        }

        for (float i = -0.2f + range; i < 0.2f + range; i += 0.05f){
            position = new Vector2(transform.position.x + i, transform.position.y);
            Debug.DrawRay(position, direction, Color.green);
            hit = Physics2D.Raycast(position, direction, raylength, groundLayer);
            if(hit.collider == null){
                count++;
            }
        }
        if(count > 2){
            return false;
        }
        return true;
    }

    private void Move(float xDistance, float yDistance){

        if (yDistance < stoppingHeight && xDistance < tooFar && Ledge())
        {
            // Speed Up Distance
            // Moves at base speed when this far away
            if (xDistance > speedUpDistance && xDistance < tooFar - speedUpDistance && !stay)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);

                // Slowing Distance
                // Slows down if between speedUpDistance and slowingDistance away from the mother
            }
            else if (xDistance > slowingDistance && xDistance < tooFar - slowingDistance && !stay)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), 0.7f * speed * Time.deltaTime);

                // Stopping Distance
                // Slows down further when less then slowingDistance but more then stoppingDistance from the mother
            }
            else if (xDistance > stoppingDistance && xDistance < tooFar - stoppingDistance && !stay)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), 0.4f * speed * Time.deltaTime);

            }
            // Stay
            // A button press makes the chick stop following the mother
            else if (stay)
            {
                transform.position = this.transform.position;
            }
        }
        else
        {
            transform.position = this.transform.position;
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