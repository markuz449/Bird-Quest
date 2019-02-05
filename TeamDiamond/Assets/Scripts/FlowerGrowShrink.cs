using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowShrink : MonoBehaviour {

    public DayNight state;

	// Use this for initialization
	void Start () {

        state = new DayNight();
    
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Change()
    {

        if (state.GetState() == true)
        {
            Debug.Log("its day");
            transform.Translate(Vector3.up * Time.deltaTime);
        }

        if (state.GetState() == false)
        {
            Debug.Log("its night");
            transform.Translate(Vector3.down * Time.deltaTime);
        }

    }

}
