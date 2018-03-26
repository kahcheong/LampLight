using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMagniGlass : MonoBehaviour {

    public GameObject glass;        //the magnifying glass
    public MagniGlass _glass;       //script controlling the magnifying glass

    public void Start()
    {
        _glass = glass.GetComponent<MagniGlass>();  //gets the script that controls the magnifying glass
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _glass.haveLight = true;    //sets the player to have the magnifying glass object
            Destroy(gameObject);        //Destroy this gameObject
        }
    }
}
