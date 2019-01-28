using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickFollow : MonoBehaviour
{

    public float speed = 6f;

    public float jumpSpeed = 5f;
    public float stoppingHeight = 2f;

    public float speedUpDistance = 3f;
    public float slowingDistance = 1f;
    public float stoppingDistance = 0.4f;
    public float tooFar = 8f;

    public float stayToggleDistance = 5f;

    private bool facingRight = true;
    private Transform target;
    private bool stay = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xDistance = Mathf.Abs(transform.position.x - target.position.x);
        if (Mathf.Abs(transform.position.y - target.position.y) < stoppingHeight && xDistance < tooFar)
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
            else if (xDistance > stoppingDistance && xDistance < tooFar - stoppingDistance &&!stay)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), 0.5f * speed * Time.deltaTime);

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



        if (Vector2.Distance(transform.position, target.position) < stayToggleDistance && Input.GetKeyDown(KeyCode.E))
        {
            stay = !stay;
        }
        if (target.position.x > transform.position.x && !facingRight)
        {
            Flip();
        }
        else if (target.position.x < transform.position.x && facingRight)
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