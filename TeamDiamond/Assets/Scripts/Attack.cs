using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Transform shotPrefab;

    public float autoShootProbability;

    public float fireCooldownTime;

    float fireCooldownTimeLeft = 0;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (fireCooldownTimeLeft > 0) {
            fireCooldownTimeLeft -= Time.fixedDeltaTime;
        }

        if (autoShootProbability > 0) {
            float randomSample = Random.Range(0f, 1f);
            if (randomSample < autoShootProbability) {
                Shoot();
            }
        }		
	}

    public void Shoot() {
        if (fireCooldownTimeLeft <= 0) {
            Transform shot = Instantiate(shotPrefab);
            shot.position = transform.position;
            fireCooldownTimeLeft = fireCooldownTime;
        }
    }
}
