using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    public GameObject lightCone;
    public GameObject obstacle;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vivi")
        {
            lightCone.active = true;
            obstacle.active = true;
        }
    }
}