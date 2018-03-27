using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resum : MonoBehaviour {

    public paseu pas;
    public GameObject pasHolder;

	// Use this for initialization
	void Start () {
        pas = pasHolder.GetComponent<paseu>();
	}

    private void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(resumee);
    }

    void resumee()
    {
        Debug.Log("resume");
        pas.paused = false;
    }

}
