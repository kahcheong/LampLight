using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {


    private void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(endGame);
    }

    void endGame()
    {
        Debug.Log("end game");
        Application.Quit();
    }
}
