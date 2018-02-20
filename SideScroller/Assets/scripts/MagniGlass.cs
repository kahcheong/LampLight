using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagniGlass : MonoBehaviour {

    public GameObject player;
    public GameObject vivi;

    private bool activated = false;
    private int lightType;
    private GameObject theLight;

    public Vector3 mouse_pos;
    public Transform target;
    public Vector3 object_pos;
    public float angle;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        vivi = GameObject.Find("vivi 1");
        target = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 100;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( new Vector3(0, 0, angle));
    }
}
