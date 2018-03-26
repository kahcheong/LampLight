using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TalkLoc : MonoBehaviour {

    public string[] message;                    //message array
    
    public GameObject player;                   //player object
    public Talk talker;                         //terxt event controller

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");     //finds player
        talker = player.GetComponent<Talk>();   //finds text event controller

    }

    void OnTriggerEnter(Collider other)         //sends the desired message to the text event controller
    {                                           //when the player enters the area
        talker.talk(message, gameObject);
        talker.talking = true;
    }



}