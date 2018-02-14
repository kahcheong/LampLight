using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieHole : MonoBehaviour {

    public GameObject spawnLedge;
    public GameObject player;

    private void OnCollisionEnter(Collision col)
    {
        player.transform.position = spawnLedge.transform.position;
    }


}
