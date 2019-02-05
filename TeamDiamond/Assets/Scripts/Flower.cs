using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    // Reference to animator component
    private Animator anim;
    // Refrence to the flower's ridgidbody
    private Rigidbody2D body = null;

    // Use this for initialization
    void Start () {
        // Initialise the reference to the Animator and rigidbody component
        anim = GetComponent<Animator>();
        body = transform.GetComponent<Rigidbody2D>();
        anim.SetTrigger("Bloom");
    }
	
    public void Bloom(){
        anim.SetTrigger("Bloom");
        body.transform.Translate(Vector3.up * 1);
    }

    public void Debloom(){
        anim.SetTrigger("Debloom");
        body.transform.Translate(Vector3.down * 1);
    }
}
