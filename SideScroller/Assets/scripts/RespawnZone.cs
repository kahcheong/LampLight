using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour {

    public GameObject player;
    public GameObject vivi;
    public float dist;
    public GameObject juiceSource;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        vivi = GameObject.Find("vivi 1");
	}
	
	// Update is called once per frame
	void Update () {

        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (dist < 5f)
        {
            juiceSource.SetActive(true);
            player.GetComponent<Respawn>().respawnZone = gameObject;
            vivi.GetComponent<Vivi>().recharge = true;
        }
        else
        {
            vivi.GetComponent<Vivi>().recharge = false;
        }
    }
}
