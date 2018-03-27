using UnityEngine;

public class juiceLevel : MonoBehaviour {

    public float min;
    public float max;
    public GameObject vivi;
    public GameObject currJuice;

    private RectTransform RT;
    private Vector3 height;
    private Vivi viviScript;

	// Use this for initialization
	void Start () {
        RT = currJuice.GetComponent<RectTransform>();
        height = RT.localScale;
        viviScript = vivi.GetComponent<Vivi>();
	}

    // Update is called once per frame
    void Update()
    {   
        if (viviScript.juice >= max)
        {
            height = new Vector3(1, 1, 1);
        }
        else if (viviScript.juice > min)
        {
            height = new Vector3(1, (viviScript.juice-min)/100f, 1);
        }
        else
        {
            height = new Vector3(1, 0, 1);
            
        }

        if (viviScript.maxJuice <= min)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }

        RT.localScale = height;
    }
}
