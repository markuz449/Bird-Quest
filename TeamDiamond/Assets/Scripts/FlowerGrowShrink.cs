using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowShrink : MonoBehaviour
{

    DayNight state;
    public bool tempState;
    Vector3 destination;

    // Use this for initialization
    void Start()
    {

        Vector3 dest = transform.position + new Vector3(0, 2, 0);

        state = new DayNight();

        transform.position = Vector3.Lerp(transform.position, dest, 0.01f);

        //tempState = state.GetState();


        //state = GameObject.FindGameObjectWithTag("GM").GetComponent<DayNight>();


    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(state.GetState());

        //tempState = astate.GetState();

        //if (tempState != state.GetState())
        //{

        //if (state.GetState() != tempState) {



    }
    //}

    //tempState = state.GetState();



    public void GrowShrink()
    {

        if (GameObject.FindGameObjectWithTag("Night"))
        {
            destination = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            Vector3.Lerp(transform.position, destination, 0.1f);
            //transform.Translate(Vector3.down * Time.deltaTime);
            //transform.position += new Vector3(0, -2, 0);

        }

        if (!GameObject.FindGameObjectWithTag("Night"))
        {
            destination = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Vector3.Lerp(transform.position, destination, 0.1f);
            //transform.Translate(Vector3.up * Time.deltaTime);
            //transform.position += new Vector3(0, 2, 0);
        }

    }


}
