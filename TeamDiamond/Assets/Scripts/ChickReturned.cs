using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickReturned : MonoBehaviour {

    public GameObject levelCompleteScreen;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Nest"))
        {
            levelCompleteScreen.SetActive(true);

        }
    }
}
