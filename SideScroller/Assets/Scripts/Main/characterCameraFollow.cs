using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 camPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        camPosition = new Vector3(0, 1.45f, -585);
    }

    void Update()
    {
        iTween.MoveUpdate(gameObject, player.transform.position + camPosition, 1);
    }
}