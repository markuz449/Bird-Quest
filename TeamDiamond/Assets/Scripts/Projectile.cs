using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public string direction;
    public int duration;

    // Use this for initialization
    void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
    

        if (direction.Equals("left")) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (direction.Equals("right")) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (direction.Equals("up")) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (direction.Equals("down")) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("Player"))

        {
        
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
