using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGlassPickup : MonoBehaviour 
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponentInChildren<MagniGlass>().blueLens = true;
			other.GetComponentInChildren<MagniGlass>().haveLight = true;
			Destroy(this.gameObject);
		}
	}
}
