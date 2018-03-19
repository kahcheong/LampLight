using System.Collections;
using System.Linq;
using UnityEngine;

public class Vivi : MonoBehaviour
{

    public GameObject player;
    public float juice = 100f;
    public GameObject lantern;

    private PlayerMove PM;
    private CharacterMotor CM;
    private bool flying;
    private Vector3 RETURN;
    private Vector3 STOP;
    public float maxJuice;
    public bool[] recharge;
    public int recharge_size = 0;
    private Rigidbody rb;
    public float maxSpeed;
    public float friction;

    public bool startFlying = false;
    private bool upA;
    private bool downA;
    private bool leftA;
    private bool rightA;
    private float x;
    private float y;

    private float flybackTime = 1f;
    public bool returned;

    private void Start()
    {
        PM = player.GetComponent<PlayerMove>();
        CM = player.GetComponent<CharacterMotor>();
        STOP = new Vector3(0, 0, 0);
        returned = true;
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RETURN = lantern.transform.position + new Vector3(0,0.2f,0);
        // checks if shift key is pressed, to start controlling vivi
        if (!startFlying) startFlying= (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && returned;
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) startFlying = false;
        flying = startFlying && juice > 0;
 
        if (Input.GetKeyDown(KeyCode.O)){
            maxJuice += 25;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            maxJuice -= 25;
        }


        //recharge = Input.GetKey(KeyCode.I);


        if (flying  ) //free flying for vivi + disables player movement
        {
            returned = false;
            Rigidbody oof = player.GetComponent<Rigidbody>();
            oof.velocity = STOP;
            CM.MoveTo(STOP, 0f, float.MaxValue, false);

            CM.currentSpeed = STOP;
            flying = true;
            PM.enabled = false;
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");


            //if (x * rb.velocity.x < 0) rb.velocity = new Vector3(0,rb.velocity.y, 0);
            //if (y * rb.velocity.y < 0) rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            

            rb.AddForce(x,y,0,ForceMode.Impulse);
            if (rb.velocity.x > maxSpeed) rb.velocity = new Vector3(maxSpeed, rb.velocity.y, 0);
            if (rb.velocity.x < -maxSpeed) rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, 0);
            if (rb.velocity.y > maxSpeed) rb.velocity = new Vector3(rb.velocity.x, maxSpeed, 0);
            if (rb.velocity.y < -maxSpeed) rb.velocity = new Vector3(rb.velocity.x, -maxSpeed, 0);

            juice -= 1.0f/3.0f;
        }
        else if (returned == false) //if vivi os far away, make her comeback and waits for her to return before allowing player to mvoe again
        {
            rb.velocity = new Vector3(0, 0, 0);
            flyback();
            StartCoroutine(flybackWait());
        }
        else if (returned == true) //vivi tracked to player after returning
        {
            rb.velocity = new Vector3(0, 0, 0);
            PM.enabled = true;
            transform.position = RETURN;
            
            if (juice < maxJuice &&  recharge.Contains(true))
            {
                juice += 1.0f;
            }
            if (juice > maxJuice)
            {
                juice -= 1.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (x == 0)
        {
            if (rb.velocity.x > 0) rb.velocity = new Vector3(rb.velocity.x - Time.deltaTime * friction, rb.velocity.y, 0);
            if (rb.velocity.x < 0) rb.velocity = new Vector3(rb.velocity.x + Time.deltaTime * friction, rb.velocity.y, 0);
        }
        if (y == 0)
        {
            if (rb.velocity.y > 0) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - Time.deltaTime * friction, 0);
            if (rb.velocity.y < 0) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + Time.deltaTime * friction, 0);
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
     * itweens vivi back to player with time as (distance^(1/3))/ something tbd
     * /*/
    void flyback()
    {
        
        float distance = Vector3.Distance(gameObject.transform.position, RETURN);
        //Debug.Log(distance);
        flybackTime = Mathf.Pow(distance, 1f / 3f) / 1.5f;
        iTween.MoveUpdate(gameObject,RETURN, flybackTime);
    }

}