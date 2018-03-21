using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysicalityTrigger : MonoBehaviour
{
    public GameObject[] obstacles;    //The list of obstacles assigned to this crystal
    public void OnEnable()
    {
        Debug.Log("We inside the cone");    //Dev check
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)    //Checks when an obstacles enters the cone
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Enter the cone");    //Dev check
            other.GetComponent<BoxCollider>().enabled = true;    //Turns on the obstacles collider
        }
    }
    
    public void OnTriggerStay(Collider other)    //Checks while an obstacles is in the cone
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Stay in the cone" + other.gameObject.name);    //Dev check
            other.GetComponent<BoxCollider>().enabled = true;    //Turns on the obstacles collider
        }
    }
    
    public void OnTriggerExit(Collider other)    //Checks for when an obstacles leaves the cone
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Leave the cone");    //Dev check
            other.GetComponent<BoxCollider>().enabled = false;    //Turns ooff the obstacles collider
        }
    }
}