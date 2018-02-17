using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour {

    public GameObject player;
    public GameObject vivi;
    public Vivi vivivi;
    public float dist;
    public GameObject juiceSource;
    private int my_ID;
    private bool succ;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        vivi = GameObject.Find("vivi 1");
        vivivi = vivi.GetComponent<Vivi>();
        my_ID = vivivi.recharge_size;
        vivivi.recharge_size++;
        vivivi.recharge = new bool[my_ID + 1];
	}
	
	// Update is called once per frame
	void Update () {

        dist = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (dist < 5f)
        {
            juiceSource.SetActive(true);
            player.GetComponent<Respawn>().respawnZone = gameObject;
            succ = true;
        }
        else
        {
            succ = false;
        }

        vivivi.recharge[my_ID] = succ;
    }
}
