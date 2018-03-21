using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieHole : MonoBehaviour 
{
    public GameObject spawnLedge;    //The ledge the platyer will spawn at from this hole
    public GameObject player;        //The player to respawn

    private void OnCollisionEnter(Collision col)
    {
        player.transform.position = spawnLedge.transform.position;    //Moves the player to the respawnPoint
    }
}
