using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displayUI : MonoBehaviour
{

    public string myString;
    public Text myText;
    public Canvas canvas;
    public float fadeTime;
    public bool displayInfo;
    private Color startColor;

    public bool shouting;
    public float duration;
    private bool _wait;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        startColor = myText.color;
        myText.color = Color.clear;
        audio = GetComponent<AudioSource>();

        _wait = true;
    }

    // Update is called once per frame
    void Update()
    {

        FadeText();  

        while (shouting && _wait)
        {
            _wait = false;
            StartCoroutine(waiting());
        }



    }

    void talk()
    {
        displayInfo = true;
    }

    void OnMouseOver()
    {
        displayInfo = true;
    }


    void OnMouseExit()

    {
        displayInfo = false;
    }


    void FadeText()

    {
        if (displayInfo)
        {

            myText.text = myString;
            myText.color = Color.Lerp(myText.color, startColor, fadeTime * Time.deltaTime);
        }

        else
        {

            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }

    IEnumerator waiting()
    {
        displayInfo = true;
        audio.Play();
        yield return new WaitForSeconds(duration);
        displayInfo = false;
        yield return new WaitForSeconds(duration);
        _wait = true;
    }


}