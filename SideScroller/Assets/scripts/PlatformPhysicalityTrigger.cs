using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysicalityTrigger : MonoBehaviour
{
    private GameObject[] obstacleArray;

    void Start()
    {
        obstacleArray = GetComponentInParent<ActivatePlatform>().obstacle;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
