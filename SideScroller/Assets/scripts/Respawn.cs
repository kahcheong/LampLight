using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject respawnZone;
    public GameObject vivi;
    private Vivi checker;

    private void Start()
    {
        vivi = GameObject.Find("vivi 1");
        checker = vivi.GetComponent<Vivi>();
    }

    void Update ()
    {

        if (checker.juice <= 0.2f)
        {
            gameObject.transform.position = respawnZone.transform.position;
            if (checker.returned) checker.juice = checker.maxJuice;
        }
	}
}
