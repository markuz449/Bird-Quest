using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFound : MonoBehaviour {

    public LevelMaster lm;
    public GameObject worm;
    private AudioSource collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collected.Play();

            lm.collectibleFound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        worm.SetActive(false);
    }

    private void Start()
    {
        collected = GetComponent<AudioSource>();
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>();
        worm = GameObject.FindGameObjectWithTag("Worm");
    }

    private void Update()
    {
        if(worm == null){
            worm = gameObject;
        }
    }
}
