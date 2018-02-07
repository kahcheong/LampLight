using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    public GameObject lightCone;
    public GameObject[] obstacle;

    private void Start()
    {
        for (int i = 0; i < obstacle.Length; i++)
        {
            if (obstacle[i] != null)
            {
                obstacle[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vivi")
        {
            lightCone.active = true;
            for(int i = 0; i < obstacle.Length; i++)
            {
                if (obstacle[i] != null)
                {
                    obstacle[i].GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
    }
}