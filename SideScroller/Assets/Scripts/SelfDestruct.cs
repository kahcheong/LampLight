using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
                                                                                                
    public GameObject[] GO;                         //Every part of the creature that will die
    public Material[] MR;                           //Array of materials to be removed
    public bool kill = false;                       //Whether it will die
    
    private void Update()                                                                       
    {                                                                                           
        if (kill) StartCoroutine("Disintegrate");      //Starts the disintegration effect
    }                                                                                           
    IEnumerator Disintegrate()                                                             
    {                                                                                     
        for (float j = 0; j < 1; j += 0.03f)            
        {                                                                                      
            for (int i = 0; i < GO.Length; i++)     //Loop through GO array
            {                                                                                  
                GO[i].GetComponent<Renderer>().material.SetFloat("_SliceAmount", j);     
                GO[i].GetComponent<Renderer>().material.SetFloat("_BurnSize", j);     
            }                                                                                 
            yield return null;           //Wait for the next killed enemy
            Debug.Log(j);     //Dev check
        }                                                                                    
        Destroy(gameObject);        //Destroy this gameObject
    }                                                                                         
}                                                                                             