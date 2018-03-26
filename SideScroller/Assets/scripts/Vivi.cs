using System.Collections;
using System.Linq;
using UnityEngine;

public class Vivi : MonoBehaviour
{

    public GameObject player;            //The player gameObject
    public float juice = 100f;           //The default player starting glow juice level
    public GameObject lantern;           //The object Vivi will return to(Should be Pod's lantern on his model)

    [SerializeField]
    private PlayerMove PM;               //The PlayerMotor
    private CharacterMotor CM;           //The CharacterMotor
    private bool flying;                 //Whether or not Vivi is being moved around
    private Vector3 RETURN;              //Vivi's return point
    private Vector3 STOP;                //Vivi's speed when stopped
    public float maxJuice;               //The maximum level of juice the player can have
    public bool[] recharge;              //Whether or not the juice is recharging
    public int recharge_size = 0;        //How much the player's juice goes up per tick
    private Rigidbody rb;                //Vivi's rigidbody
    public float maxSpeed;               //Maximum speed of Vivi
    public float friction;               //The level of friction for Vivi

    public bool startFlying = false;     //Whether Vivi should be flying
    private bool upA;                    //Whether Vivi is moving up
    private bool downA;                  //Whether Vivi is moving down
    private bool leftA;                  //Whether Vivi is moving left
    private bool rightA;                 //Whether Vivi is moving right
    private float x;                     //Vivi's current X
    private float y;                     //Vivi's current Y

    private float flybackTime = 1f;      //Time it takes Vivi to fly back to Lantern
    public bool returned;                //Whether or not Vivi is back at lantern

    private void Start()
    {
        PM = player.GetComponent<PlayerMove>();        //Player's PlayerMove
        CM = player.GetComponent<CharacterMotor>();    //Player's CharacterMotor
        STOP = new Vector3(0, 0, 0);
        returned = true;
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RETURN = lantern.transform.position + new Vector3(0,0.2f,0);    //Update the Lantern position
        // checks if shift key is pressed, to start controlling vivi
        if (!startFlying) startFlying= (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && returned;    //Whether or not Vivi should be flying based on player input
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) startFlying = false;    //Stop flying
        flying = startFlying && juice > 0;    //Atsrta flying if you have the juice
 
        if (Input.GetKeyDown(KeyCode.O)){
            maxJuice += 25;    //Dev cheat for more juice
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            maxJuice -= 25;    //Dev cheat for less juice
        }


        //recharge = Input.GetKey(KeyCode.I);


        if (flying  ) //free flying for vivi + disables player movement
        {
            returned = false;    //Vivi has not returned
            Rigidbody oof = player.GetComponent<Rigidbody>();
            oof.velocity = STOP;    //Stop the player moving
            CM.MoveTo(STOP, 0f, float.MaxValue, false);

            CM.currentSpeed = STOP;
            flying = true;
            PM.enabled = false;
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");


            //if (x * rb.velocity.x < 0) rb.velocity = new Vector3(0,rb.velocity.y, 0);
            //if (y * rb.velocity.y < 0) rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            

            rb.AddForce(x,y,0,ForceMode.Impulse);                                                    //Moving Vivi
            if (rb.velocity.x > maxSpeed) rb.velocity = new Vector3(maxSpeed, rb.velocity.y, 0);     //based on player input
            if (rb.velocity.x < -maxSpeed) rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, 0);   //allows 3D movement,
            if (rb.velocity.y > maxSpeed) rb.velocity = new Vector3(rb.velocity.x, maxSpeed, 0);     //but we restrict moving
            if (rb.velocity.y < -maxSpeed) rb.velocity = new Vector3(rb.velocity.x, -maxSpeed, 0);   //to X and Y, no Z

            juice -= 1.0f/3.0f; //Detract juice while Vivi flies
        }
        else if (returned == false) //if vivi is far away, make her comeback and waits for her to return before allowing player to mvoe again
        {
            rb.velocity = new Vector3(0, 0, 0);
            flyback();
            StartCoroutine(flybackWait());
        }
        else if (returned == true) //vivi tracked to player after returning
        {
            rb.velocity = new Vector3(0, 0, 0);    //Stop Vivi in Lantern
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