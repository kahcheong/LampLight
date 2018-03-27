using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject respawnZone;    //Zone to respawn at
    public GameObject vivi;           //Vivi gameObject
    private Vivi checker;             //For checking Vivi's remaining juice

    private void Start()
    {
        vivi = GameObject.Find("vivi 1");        //Get's Vivi
        checker = vivi.GetComponent<Vivi>();     //Get's the juice level
    }

    void Update ()
    {

        if (checker.juice <= 0.2f)    //Checks remaining juice
        {
            gameObject.transform.position = respawnZone.transform.position;    //Sets player position to respawnZone
            if (checker.returned) checker.juice = checker.maxJuice;    //
        }
	}
}
