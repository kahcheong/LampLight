using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowFruitPickup : MonoBehaviour {


    public GameObject glowFruit;
    public Collision trigger;
    // Use this for initialization
    void Start () {
        

	}

    private void OnCollisionEnter(Collision trigger)
    {
        gameObject.SetActive(false);
    }
}
