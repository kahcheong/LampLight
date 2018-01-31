using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    public float xamplitude;
    public float xspeed;
    public float yamplitude;
    public float yspeed;
    public float zamplitude;
    public float zspeed;

    private float x0;
    private float y0;
    private float z0;
    private bool waiting = false;

    // Use this for initialization
    void Start () {
        y0 = transform.position.y;
        x0 = transform.position.x;
        z0 = transform.position.z;

        xspeed = Random.Range(0.1f, 1.5f);
        yspeed = Random.Range(0.1f, 1.5f);
        zspeed = Random.Range(0.1f, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {

        float xNow = x0 + xamplitude * Mathf.Sin(xspeed * Time.time);
        float yNow = y0 + yamplitude * Mathf.Sin(yspeed * Time.time);
        float zNow = z0 + zamplitude * Mathf.Sin(zspeed * Time.time);

        gameObject.transform.position = new Vector3 (xNow, yNow, zNow);
    }

    IEnumerator oneSec()
    {

        yield return new WaitForSeconds(1f);
        xspeed = Random.Range(0.1f, 1.5f);
        yspeed = Random.Range(0.1f, 1.5f);
        zspeed = Random.Range(0.1f, 1.5f);
        
        waiting = false;
    }


}
