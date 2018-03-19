using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public GameObject[] GO;
    public Material[] MR;
    public bool kill = false;

    // Use this for initialization
    private void Update()
    {
        if (kill) StartCoroutine("Disintegrate");
    }
    IEnumerator Disintegrate()
    {
        for (float j = 0; j < 1; j += 0.03f)
        {
            for (int i = 0; i < GO.Length; i++)
            {
                GO[i].GetComponent<Renderer>().material.SetFloat("_SliceAmount", j);
                GO[i].GetComponent<Renderer>().material.SetFloat("_BurnSize", j);
            }
            yield return null;
            Debug.Log(j);
        }
        Destroy(gameObject);
    }
}
