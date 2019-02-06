using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowShrink : MonoBehaviour {

    DayNight state;
    public bool tempState;

	// Use this for initialization
	void Start () {

        state = new DayNight();
        tempState = state.GetState();

        //state = GameObject.FindGameObjectWithTag("GM").GetComponent<DayNight>();
    
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(state.GetState());

        //tempState = astate.GetState();

        //if (state.GetState() != tempState) {
        if (!GameObject.FindGameObjectWithTag("Night"))
            {
                Debug.Log("its day");
                transform.Translate(Vector3.up * Time.deltaTime);
            }

            if (GameObject.FindGameObjectWithTag("Night"))
            {
                Debug.Log("its night");
                transform.Translate(Vector3.down * Time.deltaTime);
            }
        //}
       
	}


}
