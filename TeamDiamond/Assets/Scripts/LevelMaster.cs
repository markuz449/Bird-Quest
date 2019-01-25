﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour {

    private static LevelMaster instance;

    public bool Level1;

    public bool getLevel1(){
        return Level1;


    }
    




    private void Start()
    {
        Level1 = false;

       
    }


    public void UnlockLevel1(){

        Level1 = true;
    }

    






    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {

            Destroy(gameObject);
        }
    }




}
