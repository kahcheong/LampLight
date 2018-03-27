using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public bool AUsed = false;            
    public bool DUsed = false;
    public bool FUsed = false;
    public bool SpaceUsed = false;        
    public bool ShiftUsed = false;       
           

    public Image AIcon;           
    public Image DIcon;
    public Image FIcon;
    public Image SpaceIcon;          
    public Image ShiftIcon;             

    public GameObject package;          
    public GameObject Event1;          
    public GameObject Event2;
    public GameObject Event3;

    private Color AC;                   
    private Color DC;
    private Color FC;
    private Color SpaceC;             
    private Color ShiftC;        

    // Use this for initialization
    void Start () {

        AC = AIcon.color;
        AC.a = 1f;
        AIcon.color = AC;


        DC = DIcon.color;
        DC.a = 1f;
        DIcon.color = DC;

        FC = FIcon.color;
        FC.a = 0f;
        FIcon.color = FC;


        SpaceC = SpaceIcon.color;
        SpaceC.a = 0f;
        SpaceIcon.color = SpaceC;


        ShiftC = ShiftIcon.color;
        ShiftC.a = 0f;
        ShiftIcon.color = ShiftC;

    }
	
	// Update is called once per frame
	void Update () {


        if (!AUsed && Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Fader(AIcon));
            AUsed = true;

        }
        if (!DUsed && Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Fader(DIcon));
            DUsed = true;
        }
        if (!FUsed && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(Fader(FIcon));
            FUsed = true;
        }
        if (!SpaceUsed && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Fader(SpaceIcon));
            SpaceUsed = true;
        }
        if (!ShiftUsed && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Fader(ShiftIcon));
            ShiftUsed = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Event1)
        {
            SpaceUsed = false;

            SpaceC = SpaceIcon.color;
            SpaceC.a = 1f;
            SpaceIcon.color = SpaceC;

            Destroy(other.gameObject);
        }
        if (other.gameObject == Event2)
        {
            ShiftUsed = false;

            ShiftC = ShiftIcon.color;
            ShiftC.a = 1f;
            ShiftIcon.color = ShiftC;

            Destroy(other.gameObject);
        }
        if (other.gameObject == Event3)
        {
            FUsed = false;

            FC = FIcon.color;
            FC.a = 1f;
            FIcon.color = FC;

            Destroy(other.gameObject);
        }
    }


    IEnumerator Fader (Image img)
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
