using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Fader(gameObject.GetComponent<Image>()));
	}
	


    IEnumerator Fader(Image img)
    {
        for (float f = img.color.a; f >= 0; f -= 0.05f)
        {
            Color c = img.color;
            c.a = f;
            img.color = c;
            yield return null;
        }
        Destroy(img.gameObject);
    }
}
