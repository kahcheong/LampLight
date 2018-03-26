using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//moves object along a series of waypoints, useful for moving platforms or hazards
//this class adds a kinematic rigidbody so the moving object will push other rigidbodies whilst moving
[RequireComponent(typeof(Rigidbody))]
public class MoveToPoints : MonoBehaviour 
{
	public float speed;										//how fast to move
	public float delay;										//how long to wait at each waypoint
	public type movementType;								//stop at final waypoint, loop through waypoints or move back n forth along waypoints
    
    
	
	public enum type { PlayOnce, Loop, PingPong }
	private int currentWp;
	private float arrivalTime;
	private bool forward = true, arrived = false;
	private List<Transform> waypoints = new List<Transform>();
	private CharacterMotor characterMotor;
	private EnemyAI enemyAI;
	private Rigidbody rigid;

    public bool waitForPlayer = false;
    public bool isPlatform;
    private GameObject player;
    public bool istouching;
    public bool isBugBoy;
    public float leeway = 3f;
    public GameObject myself;
    private float directiion;

    //setup
    void OnEnable()
	{
        myself = gameObject;
        //if (bp.start)
        {
            player = GameObject.Find("Player");

            if (transform.tag != "Enemy")
            {
                //add kinematic rigidbody
                if (!GetComponent<Rigidbody>())
                    gameObject.AddComponent<Rigidbody>();
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
            }
            else
            {
                characterMotor = GetComponent<CharacterMotor>();
                enemyAI = GetComponent<EnemyAI>();
            }

            rigid = GetComponent<Rigidbody>();
            //get child waypoints, then detach them (so object can move without moving waypoints)
            foreach (Transform child in transform)
                if (child.tag == "Waypoint")
                    waypoints.Add(child);

            foreach (Transform waypoint in waypoints)
                waypoint.parent = null;

            if (waypoints.Count == 0)
                Debug.LogError("No waypoints found for 'MoveToPoints' script. To add waypoints: add child gameObjects with the tag 'Waypoint'", transform);
        }
	}
	
	
	void Update()
	{
		//if we've arrived at waypoint, get the next one
		if(waypoints.Count > 0)
		{
			if(!arrived)
			{
				if (Vector3.Distance(transform.position, waypoints[currentWp].position) < 0.3f)
				{
					arrivalTime = Time.time;
					arrived = true;
				}
			}
			else
			{
				if(Time.time > arrivalTime + delay)
				{
                    if (isBugBoy) StartCoroutine(rotato());
                    GetNextWP();
					arrived = false;
				}
			}
		}
		//if this is an enemy, move them toward the current waypoint
		if(transform.tag == "Enemy" && waypoints.Count > 0)
		{
			if(!arrived)
			{
				characterMotor.MoveTo(waypoints[currentWp].position, enemyAI.acceleration, 0.1f, enemyAI.ignoreY);
				//set animator
				if(enemyAI.animatorController)
					enemyAI.animatorController.SetBool("Moving", true);
			}
			else
				//set animator
				if(enemyAI.animatorController)
					enemyAI.animatorController.SetBool("Moving", false);
		}
	}
    IEnumerator rotato()
    {
        float temp = 0;
        while (temp < 90)
        {
            gameObject.transform.Rotate(0, 0, Time.deltaTime*100);
            temp += Time.deltaTime*100;
            yield return false;
        }

        
    }
	
	//if this is a platform move platforms toward waypoint
	void FixedUpdate()
	{


        if (transform.tag != "Enemy")
		{
            if (waitForPlayer && leeway < 0)
            {
                Vector3 direction = waypoints[0].position - transform.position;
                rigid.MovePosition(transform.position + (direction.normalized * speed * Time.fixedDeltaTime));
            }
			else if(!arrived && waypoints.Count > 0)
			{
				Vector3 direction = waypoints[currentWp].position - transform.position;
				rigid.MovePosition(transform.position + (direction.normalized * speed * Time.fixedDeltaTime));
			}
		}
        if (isPlatform)
        {
            if (leeway >= 0f) leeway -= Time.deltaTime;
            waitForPlayer = true;
        }
	}

    private void OnCollisionStay(Collision col)
    {   

        if (col.gameObject.name == "Player" && col.gameObject.transform.position.y > gameObject.transform.position.y && isPlatform)
        {
            waitForPlayer = false;
            leeway = 0.5f;
        }
    }

    //get the next waypoint
    private void GetNextWP()
	{
		if(movementType == type.PlayOnce)
		{
			currentWp++;
			if(currentWp == waypoints.Count)
					enabled = false;
		}
		
		if (movementType == type.Loop)
			currentWp = (currentWp == waypoints.Count-1) ? 0 : currentWp += 1;
		
		if (movementType == type.PingPong)
		{
			if(currentWp == waypoints.Count-1)
				forward = false;
			else if(currentWp == 0)
				forward = true;
			currentWp = (forward) ? currentWp += 1 : currentWp -= 1;
		}
	}
	
	//draw gizmo spheres for waypoints
	void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		foreach (Transform child in transform)
		{
			if(child.tag == "Waypoint")
				Gizmos.DrawSphere(child.position, .7f);
		}
	}
}

/* NOTE: remember to tag object as "Moving Platform" if you want the player to be able to stand and move on it
 * for waypoints, simple use an empty gameObject parented the the object. Tag it "Waypoint", and number them in order */