using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleFound : MonoBehaviour {

    public LevelMaster lm;
    public GameObject worm;
    private AudioSource collected;
    private float soundTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Collected());
            lm.collectibleFound = true;

        }
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

    IEnumerator Collected(){
        collected.Play();
        yield return new WaitForSecondsRealtime(soundTime);
        worm.SetActive(false);
    }
}
