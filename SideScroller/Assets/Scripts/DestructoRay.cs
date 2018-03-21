using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class DestructoRay : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")    //Checks if TheoryAttribute other entity is animation enemy
        {
            other.GetComponent<SelfDestruct>().kill = true;    //Sets the kill tag to true
        }
    }
}
