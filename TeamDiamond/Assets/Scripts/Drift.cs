using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour {

    public float speed = 0.003f;
    Transform[] clouds;


	// Use this for initialization
	void Awake () {
        int childern = transform.childCount;
        clouds = new Transform[childern];
        for (int i = 0; i < childern; i++){
            clouds[i] = transform.GetChild(i);
        }

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position;
        for (int i = 0; i < clouds.Length; i++){
            position = clouds[i].localPosition;
            position.x -= speed;
            clouds[i].localPosition = position;
            if(clouds[i].localPosition.x < -80f){
                position.x = 80f;
                clouds[i].localPosition = position;
            }
        }
	}
}
