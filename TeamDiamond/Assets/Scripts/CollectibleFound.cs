using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFound : MonoBehaviour {

    public LevelMaster lm;
    public GameObject worm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            worm.SetActive(false);
            lm.collectibleFound = true;
        }
    }

    private void Start()
    {
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
