using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagniGlass : MonoBehaviour {

    public GameObject player;               //player object
    public GameObject vivi;                 //vivi object
    public GameObject Light;                //magnifyingGlass light
	
	public Boolean greenLens = false;		//Indicates whether or not the green lens has been acquired
	public Boolean blueLens = false;		//Indicates whether or not the blue lens has been acquired
	
    private bool activated = false;         //if light is currently active
    public bool haveLight = false;          //if player has picked up the magnifying glass yet
    private int lightType;                  //Indicates which lens type is selected [1: green, 2: blue]
    private GameObject theLight;
    private Vector3 posAdd;
	
    public Vector3 mouse_pos;
    public Transform target;
    public Vector3 object_pos;
    public float angle;

	// Use this for initialization
	void Start () {
        posAdd = new Vector3(0, 0.2f, 0);
        player = GameObject.Find("Player");
        vivi = GameObject.Find("vivi 1");
        target = gameObject.transform;
		Light.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = player.transform.position + posAdd;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 100;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( new Vector3(0, 0, angle));

		if (Input.GetKeyDown(KeyCode.E))
		{
			if(lightType == 0)
			{
				lightType = 1;
			}
			else if (lightType == 1)
			{
				lightType = 2;
			}
			else if (lightType == 2)
			{
				lightType = 0;
			}
		}
		if (Input.GetKeyDown(KeyCode.Q))
        		{
        			if(lightType == 0)
        			{
        				lightType = 2;
        			}
        			else if (lightType == 2)
        			{
        				lightType = 1;
        			}
        			else if (lightType == 1)
        			{
        				lightType = 0;
        			}
        		}
		
		
		if (Input.GetKeyDown(KeyCode.F) && haveLight)
		{
			activated = !activated;
		}

        Light.SetActive(activated);
		
  		
    }




}
