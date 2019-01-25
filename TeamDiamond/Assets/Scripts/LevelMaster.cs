using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour {

    private static LevelMaster instance;

    public GameObject Level1;






    private void Start()
    {

        if (Level1 != null)
        {
            Level1.SetActive(false);

        }
    }


    public void UnlockLevel1(){

        Level1.SetActive(true);
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
