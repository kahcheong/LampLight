﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZone : MonoBehaviour {
    
    public GameObject player;          //Thwe player object
    public GameObject vivi;            //Vivi's gameobject
    public Vivi vivivi;                //Vivi fior juice checking
    public float dist;                 //Distance from here to player
    public GameObject juiceSource;     //Vivi for juice checking
    private int my_ID;                 //
    private bool succ;                 //
    public GameObject lightCone;       //

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
            lightCone.SetActive(true);
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
