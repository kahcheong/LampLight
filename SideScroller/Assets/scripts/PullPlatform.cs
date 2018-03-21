using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PullPlatform : MonoBehaviour
{
	public Boolean activated = false; //Whether or not the platform should be moving
	public GameObject target; //The point the platform will move to
    [UnityEngine.Range(0,1)]
    public float speed; //Speed to target

	public Boolean returning = false;	//Whether or not the platform is going home
	public GameObject home;	//Home location of the platform
	
	void Update()
	{
		if(activated) //Checks if TheoryAttribute platform is active
		{
			transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);	//Moves the platform to it;s target at speed
		}
		if(returning)	//Checks if the platform is moving back
		{
			activated = false;	//No longer moving to target
			transform.position = Vector3.MoveTowards(this.transform.position, home.transform.position, speed);	//Moves towards home
		}
	}
}
