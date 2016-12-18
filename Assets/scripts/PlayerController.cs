using UnityEngine;
using System.Collections;

// determines player physics on input
public class PlayerController : InputController {

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
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		j = Input.GetAxis ("Jump");

	}

	// Called before any physics calculations
	public override void applyInputFixed() {

		// get direction
		Vector3 direction = GetDirection();

		// add force to player
		if (isGrounded()) {
			rb.AddForce (direction * power);
		} else {
			rb.AddForce (direction * power * airControlDamp);
		}

		// calculate velocity
		velocity = transform.position - oldPos;
		oldPos = transform.position;

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
		return (v*vDirection + h*hDirection).normalized;
	}
		
	private bool isGrounded(){
		return Physics.Raycast(transform.position, Vector3.down, distToGround);
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
}
