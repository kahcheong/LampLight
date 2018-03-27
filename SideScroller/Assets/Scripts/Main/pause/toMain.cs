using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMain : MonoBehaviour {

    private void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(leaveGame);
    }

    void leaveGame()
    {
        Debug.Log("to main");
        SceneManager.LoadScene("StartMenu");
    }
}
