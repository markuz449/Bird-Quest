using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private LevelMaster game;
    private GameMaster GM;

    //[SerializeField] Transform spawnPoint;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.transform.CompareTag("Player"))
            col.transform.position = GM.PlayerCoords();
    }

}
