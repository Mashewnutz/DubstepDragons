using UnityEngine;
using System.Collections;

public class DragonInput : MonoBehaviour {

	public GameObject tapPrefab;
	public GameObject tap;

	public float riseSpeed = 1.0f;
	public float fallSpeed = -1.0f;
	public float riseSpeedX = 4;
	public float diveSpeedX = 10;
	public float maxSpeedX = 3.0f;
	public float minSpeedX = -3.0f;
	public float maxSpeedY = 4;
	public float minSpeedY = -4;
	public float maxRotation = 40;
	public float minRotation = -40;
	public GameObject fireballPrefab;
	public float rotationSpeed = 10;

	public float lockTime = 2.0f;

	public Vector3 velocity = Vector3.zero;
	private Vector3 acceleration = Vector3.zero;
	private Animator dragonAnimation;
	private bool rising = false;
	private bool falling = true;
	private float timeHeld = 0;
	// Use this for initialization
	void Start () {
		dragonAnimation = gameObject.GetComponentInChildren<Animator> ();
		velocity.x = 3;

		tap = Instantiate(tapPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		timeHeld += Time.deltaTime;

		if (Input.GetMouseButtonDown(0)){
//			dragonAnimation.SetBool("Rising", false);
			falling = false;
			rising = true;
			timeHeld = 0;
			lockTime = 0.0f;
		}
		else if(Input.GetMouseButtonUp(0)){
			rising = false;
			falling = true;
//			dragonAnimation.SetBool("Rising", true);
		}

		UpdateAcceleration ();
		UpdateVelocity ();
		UpdatePosition ();

		float rotation = (velocity.y / maxSpeedY) * maxRotation;
		transform.rotation = Quaternion.AngleAxis (rotation, new Vector3 (0, 0, 1));
	}

	void UpdateAcceleration()
	{
		float accelerationY = 0;
		float accelerationX = 0;
		if (rising) 
		{
			accelerationY = riseSpeed;
		}

		if(falling)
		{
			accelerationY = fallSpeed + timeHeld;
			accelerationX = diveSpeedX;
		}
		acceleration.Set (accelerationX, accelerationY, 0);
	}

	void UpdateVelocity()
	{
		velocity += acceleration * Time.deltaTime;

		if(rising)
		{
			velocity -= new Vector3(Time.deltaTime, 0, 0);
		}
		float velX = Mathf.Clamp(velocity.x, minSpeedX, maxSpeedX);
		float velY = Mathf.Clamp(velocity.y, minSpeedY, maxSpeedY);
		float velZ = 0;
		velocity.Set (velX, velY, velZ);
	}

	void UpdatePosition()
	{
		Vector3 deltaPosition = velocity * Time.deltaTime;

		lockTime -= Time.deltaTime;
		if (lockTime > 0.0f)
		{
			deltaPosition.y = 0;
		}
		else if (tap)
		{
			Destroy(tap);
			tap = null;
		}

		transform.position = transform.position + deltaPosition;
	}
			          
}
