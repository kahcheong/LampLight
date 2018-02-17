using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displayUI : MonoBehaviour
{

    public string myString;                            //String to display
    public Text myText;                                //The text of the 
    public Canvas canvas;                              //The display canvas for the UI
    public float fadeTime;                             //The time to fade the text in
    public bool displayInfo;                           //Whether or not to display info
    private Color startColor;                          //The colour of the text

    public bool shouting;                              //
    public float duration;                             //Time to display the text
    private bool _wait;                                //Whether or not the game is waiting for something
    public AudioSource audio;                          //Audio to be played

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