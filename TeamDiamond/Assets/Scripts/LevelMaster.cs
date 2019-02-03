﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMaster : MonoBehaviour {

    private static LevelMaster instance;
    public bool hasreset;
    public int resets;

    public bool Level1;

    public bool getLevel1(){
        return Level1;


    }

    public void PlayerReset(){
        hasreset = true;
        resets++;

    }

    public int getNumResets(){

        return resets;

    }

    public void ClearReset(){

        hasreset = false;

    }


    public bool getReset()
    {
        return hasreset;


    }


    private void Start()
    {
        Level1 = false;
        hasreset = false;

       
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
