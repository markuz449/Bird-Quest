using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    // Reference to animator component
    Animator anim;

    // Use this for initialization
    void Start () {
        // Initialise the reference to the Animator component
        anim = GetComponent<Animator>();
        anim.SetTrigger("Bloom");
    }
	
    public void Bloom(){
        anim.SetTrigger("Bloom");
    }

    public void Debloom(){
        anim.SetTrigger("Debloom");
    }
}
