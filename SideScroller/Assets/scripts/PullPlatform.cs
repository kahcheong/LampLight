using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlatform : MonoBehaviour
{
	public Boolean activated = false; //Whether or not the platform should be moving
	public GameObject target; //The point the platform will move to
	void Update()
	{
		if(activated)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 0.01f);
		}
	}
}
