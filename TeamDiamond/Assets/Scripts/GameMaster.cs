using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;




    public Vector3 lastCheckpointPos;

    public Vector3 chickLastCheckpoint;






    public Vector3 PlayerCoords(){

        return lastCheckpointPos;
    }

    public Vector3 ChickCoords()
    {

        return chickLastCheckpoint;
    }



    private void Awake()
    {
        if(instance == null){

            instance = this;
            DontDestroyOnLoad(instance);
        } else {

            Destroy(gameObject);
        }
    }


}
