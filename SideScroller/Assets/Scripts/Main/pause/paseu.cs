using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paseu : MonoBehaviour
{

    public bool paused = false;
    public GameObject pause;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKey("escape")) paused = true;

    }
}
