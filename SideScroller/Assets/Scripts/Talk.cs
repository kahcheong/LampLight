using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Talk : MonoBehaviour {

    public bool talking;
    public GameObject player;
    public GameObject used;
    public GameObject zone;
    public string[] curr;
    public int progress;

    public Canvas _canvas;
    public Text _text;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        _text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (talking)
        {
            zone.SetActive(true);
            player.GetComponent<PlayerMove>().enabled = false;
        }
        else
        {
            zone.SetActive(false);
            player.GetComponent<PlayerMove>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Return) )
        {
            if (curr == null || progress == curr.Length-1)
            {
                _text.text = "";
                talking = false;
                if (used != null) Destroy(used);
            }
            else
            {
                progress++;
                _text.text = curr[progress];
            }
            
        }
    }

    public void talk(string[] message, GameObject g)
    {
        talking = true;
        used = g;
        int temp = 0;
        if (message.Length > 1) curr = message;
        else curr = null;
        progress = 0;


        _text.text = message[0];
    }
}
