using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlatform : MonoBehaviour
{
	public Boolean activated = false; //Whether or not the platform should be moving
	public GameObject target; //The point the platform will move to
    [Range(0,1)]
    public float speed; //Speed to target
	void Update()
	{
		if(activated)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
		}
	}
}
