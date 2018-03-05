using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Talk : MonoBehaviour {

    public bool talking;
    public GameObject player;
    public GameObject used;

    public string[] message;
    public string[] identifier;
    public Canvas _canvas;
    public Text _text;


	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        _text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (talking) player.GetComponent<PlayerMove>().enabled = false;
        else player.GetComponent<PlayerMove>().enabled = true;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _text.text = "";
            talking = false;
            if (used != null) Destroy(used);
        }
    }

    public void talk(string idn, GameObject g)
    {
        talking = true;
        used = g;
        int temp = 0;

        for (int i = 0; i < identifier.Length; i++)
        {
            if (idn.Equals(identifier)) temp = i;
        }
        _text.text = message[temp];
    }
}
