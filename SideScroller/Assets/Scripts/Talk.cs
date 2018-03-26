using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Talk : MonoBehaviour {

    public bool talking;            //whether text event is currently happening
    public GameObject player;       //player object
    public GameObject used;         //previous text zone
    public GameObject zone;         //text box
    public string[] curr;           //message array to be displayed 
    public int progress;            //progression through message array

    public Canvas _canvas;          //canvas text is displayed on
    public Text _text;              //text area message is written on


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");     //finding player object
        _text.text = "";                        //clearing text zrea
	}
	
	// Update is called once per frame
	void Update () {
        if (talking)                //if currently in text event                                             
        {
            zone.SetActive(true);                                   //reveal text box
            player.GetComponent<PlayerMove>().enabled = false;      //stop player controller
        }
        else                        //if not currently in text event
        {
            zone.SetActive(false);                                  //hide text box
            player.GetComponent<PlayerMove>().enabled = true;       //reactivate player controller
        }

        if (Input.GetKeyDown(KeyCode.Return) )                      //check for player input for text event progression
        {
            if (curr == null || progress == curr.Length-1)          //check if text event is only 1 message long
            {                                                       //or if it is on the last message 

                _text.text = "";                                    //clears the text area
                talking = false;                                    //ends text event
                if (used != null) Destroy(used);                    //destroy used text event trigger
            }
            else                                                    //if there are more messages
            {
                progress++;                                         //increment the message tracker
                _text.text = curr[progress];                        //sends the next message
            }
            
        }
    }

    public void talk(string[] message, GameObject g)
    {
        talking = true;                                             //starts text event
        used = g;                                                   //save the triggered text event trigger
        if (message.Length > 1) curr = message;                     //if message is longer than one message, store the array
        else curr = null;                                           //else keep the storage empty
        progress = 0;                                               //set the tracker to 0
        _text.text = message[0];                                    //set the text area to the first message
    }
}
