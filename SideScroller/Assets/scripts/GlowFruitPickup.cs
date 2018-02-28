using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowFruitPickup : MonoBehaviour {


    public GameObject glowFruit;
    public Collision trigger;

    private Vivi vivi;
    // Use this for initialization

    void Start () {
        vivi = GameObject.Find("vivi 1").GetComponent<Vivi>();

	}

    private void OnCollisionEnter(Collision trigger)
    {
        vivi.maxJuice += 25;
        gameObject.SetActive(false);
    }
}
