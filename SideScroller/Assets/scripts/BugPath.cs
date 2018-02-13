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

    private float width;
    private float height;

    private void Start()
    {
        Transform rt = block.transform;

        width = block.transform.localScale.x + gameObject.transform.localScale.x / 2;
        height = block.transform.localScale.y + gameObject.transform.localScale.y / 2;


        if (clockwise)
        {
            wayPoint_1.transform.position = new Vector3(rt.position.x - width / 2, rt.position.y + height / 2, rt.position.z);
            wayPoint_2.transform.position = new Vector3(rt.position.x + width / 2, rt.position.y + height / 2, rt.position.z);
            wayPoint_3.transform.position = new Vector3(rt.position.x + width / 2, rt.position.y - height / 2, rt.position.z);
            wayPoint_4.transform.position = new Vector3(rt.position.x - width / 2, rt.position.y - height / 2, rt.position.z);
        }
        else
        {
            wayPoint_1.transform.position = new Vector3(rt.position.x - width / 2, rt.position.y + height / 2, rt.position.z);
            wayPoint_2.transform.position = new Vector3(rt.position.x - width / 2, rt.position.y - height / 2, rt.position.z);
            wayPoint_3.transform.position = new Vector3(rt.position.x + width / 2, rt.position.y - height / 2, rt.position.z);
            wayPoint_4.transform.position = new Vector3(rt.position.x + width / 2, rt.position.y + height / 2, rt.position.z);
        }
        gameObject.GetComponent<MoveToPoints>().enabled = true;

    }

}
