using UnityEngine;
using System.Collections;

// determines player physics on input
public class PlayerController : InputController {

	public float TOUCH_RANGE = 50f;

	public float power = 100f;
	private float airControlDamp = 0.2f;
	private float distToGround = 0.85f; 
	public float aimTurnSmoothing = 15.0f;
	public float turnSmoothing = 3.0f;

	private float h;
	private float v;
	private float j;
	private Vector3 lastDirection;
	private bool colliding;

	public Vector3 oldPos = new Vector3(0,0,0); // init for no null error
	public Vector3 velocity;

	private Rigidbody rb;
	private Transform cameraTransform;

	private PowerupManager powerupManager;

	private bool inSpace = false;
	private bool inWater = false;

	private Vector2 touchOrigin = -Vector2.one;

	// Use this for initialization
	protected override void afterStart () {
		setAsActiveInputController ();
		rb = GetComponent<Rigidbody>();
		powerupManager = GameObject.FindObjectOfType<PowerupManager> (); 
	}

	void Awake() {
		cameraTransform = Camera.main.transform;
	}
		
	// called every frame when this is the active InputController
	public override void applyInput() {
	}

	// Called before any physics calculations
	public override void applyInputFixed() {
	  //#if UNITY_STANDALONE
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		j = Input.GetAxis ("Jump");
	  //#else

		if (Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began){
				touchOrigin = touch.position;
			}
				

			h = (touch.position.x - touchOrigin.x)/TOUCH_RANGE;
			v = (touch.position.y - touchOrigin.y)/TOUCH_RANGE;
		}

	  //#endif
		// get direction
		Vector3 direction = GetDirection();
		// add force to player
		if (isGrounded() && !inSpace || inWater) {
			rb.AddForce (direction * power);

		} else {
			rb.AddForce (direction * power * airControlDamp);
		}

		// calculate velocity
		// TODO: velocity is a field in rb
		velocity = transform.position - oldPos;
		oldPos = transform.position;

		// add extra force for more velocity
		/*
		float extraVelocityTorque = velocity.magnitude;
		float extraVelocityForce = logisticForExtraPower (rb.velocity.magnitude) * power/2.0f;
		print(logisticForExtraPower(rb.velocity.magnitude));
		*/
		//rb.AddTorque (new Vector3(direction.z, 0, -direction.x) * extraVelocityTorque);
		//rb.AddForce (direction * extraVelocityForce);
			

		// use a powerup
		if (j != 0 && powerupManager.powerLevel > 0 && powerupManager.powerup != null) {
			powerupManager.use ();
		}

	}

	// called when the InputController is no longer active
	public override void disableInput() {
		h = 0;
		v = 0;
	}

	// get the direction based on the camera's position
	private Vector3 GetDirection(){
		float yRotation = Mathf.Deg2Rad * cameraTransform.eulerAngles.y;
		float sinYRot = Mathf.Sin (yRotation);
		float cosYRot = Mathf.Cos (yRotation);
		Vector3 vDirection = new Vector3 (sinYRot, 0.0f, cosYRot);
		Vector3 hDirection = new Vector3 (cosYRot, 0.0f, -sinYRot);

		Vector3 direction = v * vDirection + h * hDirection;
		if (direction.magnitude > 1)
			direction.Normalize (); 

		//clamp magnitude to 1
		if (direction.magnitude > 1) {
			direction.Normalize ();
		}
		return direction;
	}
		
	private bool isGrounded(){
		return Physics.Raycast(transform.position, Vector3.down, distToGround);
	}

	public void setInSpace(bool b){
		inSpace = b;
	}

	public void setInWater(bool b){ 
		inWater = b;
	}

	// functions for orbit camera
	public bool IsFlying(){
		return false;
	}

	public bool IsAiming(){
		return false;
	}

	public bool IsSprinting(){
		return false;
	}

	private static float logisticForExtraPower(float x){
		return 1.0f / (1.0f + Mathf.Exp (-0.2f * (x - 15.0f)));
	}
}
