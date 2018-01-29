using System.Collections;
using UnityEngine;

public class Vivi : MonoBehaviour
{

    public GameObject player;

    private PlayerMove PM;
    private CharacterMotor CM;
    private bool flying;
    private Vector3 RETURN;
    private Vector3 STOP;


    private float flybackTime = 1f;
    private bool returned;
    private bool returning = false;

    private void Start()
    {
        PM = player.GetComponent<PlayerMove>();
        CM = player.GetComponent<CharacterMotor>();
        RETURN = new Vector3(-0.75f, 0.75f, -0.75f);
        STOP = new Vector3(0, 0, 0);
        returned = true;
    }

    void Update()
    {   
        // checks if shift key is pressed, to start controlling vivi
        flying = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
 



        if (flying  ) //free flying for vivi + disables player movement
        {
            returned = false;
            Rigidbody oof = player.GetComponent<Rigidbody>();
            oof.velocity = STOP;
            CM.MoveTo(STOP, 0f, float.MaxValue, false);

            CM.currentSpeed = STOP;
            flying = true;
            PM.enabled = false;
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 4.5f;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * 4.5f;

            transform.Translate(x, y, 0);
            returning = false;
        }
        else if (returned == false) //if vivi os far away, make her comeback and waits for her to return before allowing player to mvoe again
        {
            
            if (!returning)
            {
                flyback();
                returning = true; ;
            }
           
            StartCoroutine(flybackWait());
        }
        else if (returned == true) //vivi tracked to player
        {
            PM.enabled = true;
            transform.position = player.transform.position + RETURN;
        }
    }

    /*
     * waits for viv to return to player
     * /*/
    IEnumerator flybackWait()
    {
        
        yield return new WaitForSeconds( flybackTime);
        returned = true;
    }

    /*
     * itweens vivi back to player with time as (distance^(1/3))/2
     * /*/
    void flyback()
    {
        
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position + RETURN);
        Debug.Log(distance);
        flybackTime = Mathf.Pow(distance, 1f / 3f) / 2.2f;
        iTween.MoveTo(gameObject, player.transform.position + RETURN, flybackTime);
    }

}