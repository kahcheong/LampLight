﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrackedPink : MonoBehaviour 
{
    public GameObject spotLight;
    public GameObject LightCone;                                          
    public GameObject[] obstacle;
    public GameObject colliderCone;

    public float expandSpeed;                                           //rate in which the light cone extends at  
    public GameObject particles1;                                       //1st particle 
    public GameObject particles2;                                       //2nd particle 
    public GameObject particles3;                                       //3rd particle 
    private Light light;                                                //spotlight's light component
    private bool on = false;                                            //the crystals current state
    private bool fade = false;                                          //control for the crystal's pulsation
    private ParticleSystem p1;                                          //1st particle system controller
    private ParticleSystem p2;                                          //2nd particle system controller
    private ParticleSystem p3;                                          //3rd particle system controller
    
    [Tooltip("The time to keep the platform activated")]
    public float activationTime;                                        //Activation time for the platform

    [SerializeField]
    private float activeTime;                                            //The time the crystal has been active

    private void Start()
    {
        light = spotLight.GetComponent<Light>();                        // get the light componenet for the spot light
        p1 = particles1.GetComponent<ParticleSystem>();                 // particle controller for the 3 particle systems being used
        p2 = particles2.GetComponent<ParticleSystem>();
        p3 = particles3.GetComponent<ParticleSystem>();

        p1.emissionRate = 0;                                            // resets all particle systems emmission to 0
        p2.emissionRate = 0;
        p3.emissionRate = 0;

        light.range = 4;                                                //preps the light to be at the correct interval to match the base's pulsation
        //LightCone.transform.localPosition += new Vector3(0, 13, 0);     // preps the revealer shader to be at~the same position as the light

        for (int i = 0; i < obstacle.Length; i++)
        {
            if (obstacle[i] != null)
            {
               // obstacle[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
        colliderCone.active = false;
        LightCone.active = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vivi" || other.tag == "MagniGlass")
        {
            Debug.Log(other.tag + " activated me");    //Dev check
            on = true;
            colliderCone.active = true;
            LightCone.active = true;
        }
    }

    /*
     * used mostly for "animation" for the light being activate
     * 
     **/
    private void Update()
    {

        if (on)
        {
            if (light.range < 30)                                       //progressively extends the cone of light after crystal is activated
            {
                light.range += Time.deltaTime * expandSpeed;
            }
            if (p1.emissionRate < 40 && light.range>15)                 //progressively grows the particle systems when crystal is activated 
            {                                                           //and the light cone has extended to a certain amount
                p1.emissionRate += Time.deltaTime * expandSpeed;
                p2.emissionRate += Time.deltaTime * expandSpeed;
                p3.emissionRate += Time.deltaTime * expandSpeed;
            }
            activeTime += Time.deltaTime;
            if (activeTime >= activationTime)                            //Handles when the timer is up for the crystal
            {
                activeTime = 0;
                on = false;
                p1.emissionRate = 0;                                            
                p2.emissionRate = 0;
                p3.emissionRate = 0;

                light.range = 4;      
            }
            
        }
        if(activeTime == 0)
        {
            for (int i = 0; i < obstacle.Length; i++)
            {
                if (obstacle[i] != null)
                {
                    obstacle[i].GetComponentInChildren<PullPlatform>().returning = true;
                    obstacle[i].GetComponentInParent<PullPlatform>().enabled = true;
                }
            }
        }
        else
        {
            if (!fade)                                                  //tries to match the idle pulsation for the base of the crystal
            {
                light.range += Time.deltaTime * 3f;
                if (light.range > 10) fade = true;
            }
            else
            {
                light.range -= Time.deltaTime * 3f;
                if (light.range < 4) fade = false;
            }
        }
    }
}
