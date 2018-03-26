using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TalkLoc : MonoBehaviour {

    public string[] message;
    
    public GameObject player;
    public Talk talker;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        talker = player.GetComponent<Talk>();

    }

    void OnTriggerEnter(Collider other)
    {
        talker.talk(message, gameObject);
        talker.talking = true;
    }



}