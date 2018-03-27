using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGlassPickup : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<MagniGlass>().greenLens = true;
            other.GetComponentInChildren<MagniGlass>().haveLight = true;
            Destroy(this.gameObject);
        }
    }
}
