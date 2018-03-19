using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructoRay : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<SelfDestruct>().kill = true;
        }
    }
}
