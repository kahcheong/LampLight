using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Time.timeScale = 7;
        if (Input.GetMouseButtonUp(0)) Time.timeScale = 1;

        if (Input.GetKey("escape")) SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
