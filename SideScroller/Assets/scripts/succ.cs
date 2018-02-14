using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class succ : MonoBehaviour {

    public GameObject moth;

	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.LookAt(moth.transform.position);
	}
}
