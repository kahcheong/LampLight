using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugPath : MonoBehaviour
{

    public GameObject block;
    public GameObject wayPoint_1;
    public GameObject wayPoint_2;
    public GameObject wayPoint_3;
    public GameObject wayPoint_4;
    public bool clockwise;
    public GameObject bugBoy;

    private float width;
    private float height;
    private BoxCollider bc;
    public Vivi vivi;

    private void Start()
    {
        Transform rt = block.transform;
        bc = block.GetComponent<BoxCollider>();

        width = bc.bounds.size.x;
        height = bc.bounds.size.y;

        var temp = bugBoy.GetComponent<BoxCollider>().bounds.size.y;

        var w = gameObject.transform.localScale.x;
        var h = gameObject.transform.localScale.y;

        if (clockwise)
        {
            wayPoint_4.transform.position = new Vector3(rt.position.x - width / 2 - temp / 2, rt.position.y + height + temp / 2, rt.position.z);
            wayPoint_3.transform.position = new Vector3(rt.position.x - width / 2 - temp / 2, rt.position.y - temp, rt.position.z);
            wayPoint_2.transform.position = new Vector3(rt.position.x + width / 2 + temp / 2, rt.position.y - temp, rt.position.z);
            wayPoint_1.transform.position = new Vector3(rt.position.x + width / 2 + temp / 2, rt.position.y + height + temp / 2, rt.position.z);
        }
        else
        {
            wayPoint_1.transform.position = new Vector3(rt.position.x - width / 2 - temp/2, rt.position.y + height + temp/2, rt.position.z);
            wayPoint_2.transform.position = new Vector3(rt.position.x - width / 2 - temp/2, rt.position.y - temp , rt.position.z);
            wayPoint_3.transform.position = new Vector3(rt.position.x + width / 2 + temp/2, rt.position.y - temp , rt.position.z);
            wayPoint_4.transform.position = new Vector3(rt.position.x + width / 2 + temp/2, rt.position.y + height + temp/2 , rt.position.z);
        }
        gameObject.GetComponent<MoveToPoints>().enabled = true;

    }

    public void OnCollisionEnter(Collision other)
    {
        
    }

}
