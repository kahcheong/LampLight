using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMagniGlass : MonoBehaviour {

    public GameObject glass;
    public MagniGlass _glass;

    public void Start()
    {
        _glass = glass.GetComponent<MagniGlass>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _glass.haveLight = true;
        }
    }
}
