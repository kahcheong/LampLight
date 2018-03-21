using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuiceWobble : MonoBehaviour 
{

    public Sprite[] juices;    //How many jars of juice you can have
    public int counter = 0;    
    public GameObject self;
    bool wait = false;

    private void Start()
    {
        counter = (int)Random.Range(0, juices.Length);
    }

    private void FixedUpdate()
    {
        if (!wait)
        {
            counter = ((counter + 1) % juices.Length);
            Image temp = self.GetComponent<Image>();
            temp.sprite = juices[counter];
            wait = true;
            StartCoroutine(hwait());
        }
    }

    IEnumerator hwait()
    {

        yield return new WaitForSeconds(0.1f);
        wait = false;
    }
}

