using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugPath : MonoBehaviour {

    public float duration;
    public string path;

    private bool _wait = true;
	
	// Update is called once per frame
	void Update () {
	    if (_wait)
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(path), "time", 5));
            _wait = false;
            StartCoroutine(waiting());
        }	


	}

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(duration);
        _wait = true;
    }


}
