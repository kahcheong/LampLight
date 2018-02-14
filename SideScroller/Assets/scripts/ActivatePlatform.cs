using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    public GameObject lightCone;
    public GameObject[] obstacle;
    public GameObject colliderCone;
    private void Start()
    {
        for (int i = 0; i < obstacle.Length; i++)
        {
            if (obstacle[i] != null)
            {
                obstacle[i].GetComponent<BoxCollider>().enabled = false;
            }
        }

        colliderCone.active = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vivi")
        {
            Debug.Log("Vivi activated me");
            lightCone.active = true;
            colliderCone.active = true;
        }
    }
}