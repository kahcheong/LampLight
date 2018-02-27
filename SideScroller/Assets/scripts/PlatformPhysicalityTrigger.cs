﻿using System;
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
            obstacles[i].GetComponentInChildren<PullPlatform>().activated = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Enter the cone");
            other.GetComponent<BoxCollider>().enabled = true;
            other.GetComponentInChildren<PullPlatform>().activated = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Stay in the cone");
            other.GetComponent<BoxCollider>().enabled = true;
            other.GetComponentInChildren<PullPlatform>().activated = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Leave the cone");
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponentInChildren<PullPlatform>().activated = false;
        }
    }
}
