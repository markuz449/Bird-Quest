using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spin : MonoBehaviour
{
    public float speed = 150f;


    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
