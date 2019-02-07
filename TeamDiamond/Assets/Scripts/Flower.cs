using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    // Reference to animator component
    private Animator anim;
    // Refrence to the flower's ridgidbody
    private Rigidbody2D body = null;
    private bool bloomed;

    // Use this for initialization
    void Start () {
        // Initialise the reference to the Animator and rigidbody component
        anim = GetComponent<Animator>();
        body = transform.GetComponent<Rigidbody2D>();
        anim.SetTrigger("Bloom");
        bloomed = true;
    }
	
    public void Bloom(){
        anim.SetTrigger("Bloom");
        //moveColliders(true);
    }

    public void Debloom(){
        anim.SetTrigger("Debloom");
        //moveColliders(false);
    }

    //private void moveColliders(bool blooming){
    //    if (blooming != bloomed && blooming == true){
    //        body.transform.Translate(Vector3.up * 6);
    //        bloomed = true;
    //    } 
    //    else if(blooming != bloomed && blooming == false){
    //        body.transform.Translate(Vector3.down * 6);
    //        bloomed = false;
    //    }
    //}
}
