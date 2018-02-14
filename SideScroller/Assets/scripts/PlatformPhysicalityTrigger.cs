using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysicalityTrigger : MonoBehaviour
{
    public GameObject[] obstacles;
    public void OnEnable()
    {
        Debug.Log("We inside the cone");
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("We made it bois");
            other.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("BEGONE");
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
