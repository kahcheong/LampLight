using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomActivate : MonoBehaviour {

    public GameObject lights;
    public GameObject particle;
    public Animation on;
    private bool iSNotPlayed = true;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        lights.active = true;
        particle.active = true;
        if(iSNotPlayed)
        { on.Play();
            iSNotPlayed = false;
        }
       

    }
}
