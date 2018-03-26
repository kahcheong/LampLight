using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructoRay : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("light on" + other.name);
        if (other.tag == "Enemy")    //Checks if TheoryAttribute other entity is animation enemy
        {
            other.GetComponent<SelfDestruct>().kill = true;    //Sets the kill tag to true
        }
    }
}
