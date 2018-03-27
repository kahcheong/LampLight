using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour {


    private void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(startGame);
    }

    void startGame()
    {
        Debug.Log("load intro");
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }
}
