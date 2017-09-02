using UnityEngine;
using System.Collections;

public class ThirdPersonOrbitCam : Singleton<ThirdPersonOrbitCam> 
{
	private const float TOUCH_RANGE = 400f; // in pixels

	public Transform player;
	public Texture2D crosshair;
	
	public Vector3 pivotOffset = new Vector3(0.0f, 1.0f,  0.0f);
	public Vector3 camOffset   = new Vector3(0.0f, 0.7f, -3.0f);

	public float smooth = 10f;

	public Vector3 aimPivotOffset = new Vector3(0.0f, 1.7f,  -0.3f);
	public Vector3 aimCamOffset   = new Vector3(0.8f, 0.0f, -1.0f);

	public float horizontalAimingSpeed = 400f;
	public float verticalAimingSpeed = 400f;
	public float maxVerticalAngle = 30f;
	public float flyMaxVerticalAngle = 60f;
	public float minVerticalAngle = -60f;
	
	public float mouseSensitivity = 0.3f;

	public float sprintFOV = 100f;
	
	private PlayerController playerController;
	private float angleH = 0;
	private float angleV = 0;
	private Transform cam;

	private Vector3 relCameraPos;
	private float relCameraPosMag;
	
	private Vector3 smoothPivotOffset;
	private Vector3 smoothCamOffset;
	private Vector3 targetPivotOffset;
	private Vector3 targetCamOffset;

	private float defaultFOV;
	private float targetFOV;

	// touch input
	private Vector2 orbitTouchOrigin = -Vector2.one;
	private const int NULL_TOUCH_INDEX = -1;
	private int orbitTouchIndex = NULL_TOUCH_INDEX;

	void Awake()
	{
		cam = transform;
		playerController = player.GetComponent<PlayerController> ();

		relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;

		smoothPivotOffset = pivotOffset;
		smoothCamOffset = camOffset;

		defaultFOV = cam.GetComponent<Camera>().fieldOfView;
	}

	void LateUpdate()
	{
		// get inputs from mouse
		float mouseX = Mathf.Clamp (Input.GetAxis ("Mouse X"), -1, 1) * horizontalAimingSpeed * Time.deltaTime;
		float mouseY = Mathf.Clamp (Input.GetAxis ("Mouse Y"), -1, 1) * verticalAimingSpeed * Time.deltaTime;
		// get inputs from joystick
		float rjoyX = Mathf.Clamp(Input.GetAxis("xboxRJoyX"), -1, 1) * horizontalAimingSpeed * Time.deltaTime;
		float rjoyY = -1* Mathf.Clamp(Input.GetAxis("xboxRJoyY"), -1, 1) * verticalAimingSpeed * Time.deltaTime;
		// get inputs from touch
		Vector2 touchMovement = getOrbitTouchMovement()/TOUCH_RANGE;

		float rTouchX = Mathf.Clamp(touchMovement.x, -1, 1) * horizontalAimingSpeed * Time.deltaTime;
		float rTouchY = Mathf.Clamp(touchMovement.y, -1, 1) * verticalAimingSpeed * Time.deltaTime;

		// apply inputs
		angleH += mouseX + rjoyX + rTouchX;
		angleV += mouseY + rjoyY + rTouchY;

		// fly
		if(playerController.IsFlying())
		{
			angleV = Mathf.Clamp(angleV, minVerticalAngle, flyMaxVerticalAngle);
		}
		else
		{
			angleV = Mathf.Clamp(angleV, minVerticalAngle, maxVerticalAngle);
		}


		Quaternion aimRotation = Quaternion.Euler(-angleV, angleH, 0);
		Quaternion camYRotation = Quaternion.Euler(0, angleH, 0);
		cam.rotation = aimRotation;

		if(playerController.IsAiming())
		{
			targetPivotOffset = aimPivotOffset;
			targetCamOffset = aimCamOffset;
		}
		else
		{
			targetPivotOffset = pivotOffset;
			targetCamOffset = camOffset;
		}

		if(playerController.IsSprinting())
		{
			targetFOV = sprintFOV;
		}
		else
		{
			targetFOV = defaultFOV;
		}
		cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp (cam.GetComponent<Camera>().fieldOfView, targetFOV,  Time.deltaTime);

		// Test for collision
		Vector3 baseTempPosition = player.position + camYRotation * targetPivotOffset;
		Vector3 tempOffset = targetCamOffset;
		for(float zOffset = targetCamOffset.z; zOffset <= 0; zOffset += 0.5f)
		{
			tempOffset.z = zOffset;
			if (DoubleViewingPosCheck (baseTempPosition + aimRotation * tempOffset) || zOffset == 0) 
			{
				targetCamOffset.z = tempOffset.z;
				break;
			} 
		}

		// fly
		if(playerController.IsFlying())
		{
			targetCamOffset.y = 0;
		}

		smoothPivotOffset = Vector3.Lerp(smoothPivotOffset, targetPivotOffset, smooth * Time.deltaTime);
		smoothCamOffset = Vector3.Lerp(smoothCamOffset, targetCamOffset, smooth * Time.deltaTime);

		cam.position =  player.position + camYRotation * smoothPivotOffset + aimRotation * smoothCamOffset;

	}

	// concave objects doesn't detect hit from outside, so cast in both directions
	bool DoubleViewingPosCheck(Vector3 checkPos)
	{
		float playerFocusHeight = player.GetComponent<CapsuleCollider> ().height *0.5f;
		return ViewingPosCheck (checkPos, playerFocusHeight) && ReverseViewingPosCheck (checkPos, playerFocusHeight);
	}

	bool ViewingPosCheck (Vector3 checkPos, float deltaPlayerHeight)
	{
		RaycastHit hit;
		
		// If a raycast from the check position to the player hits something...
		if(Physics.Raycast(checkPos, player.position+(Vector3.up* deltaPlayerHeight) - checkPos, out hit, relCameraPosMag))
		{
			// ... if it is not the player...
			if(hit.transform != player && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				// This position isn't appropriate.
				return false;
			}
		}
		// If we haven't hit anything or we've hit the player, this is an appropriate position.
		return true;
	}

	bool ReverseViewingPosCheck(Vector3 checkPos, float deltaPlayerHeight)
	{/*
		RaycastHit hit;

		if(Physics.Raycast(player.position+(Vector3.up* deltaPlayerHeight), checkPos - player.position, out hit, relCameraPosMag))
		{
			if(hit.transform != player && hit.transform != transform && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				return false;
			}
		}*/
		return true;
	}

	// Crosshair
	void OnGUI () 
	{
		float mag = Mathf.Abs ((aimPivotOffset - smoothPivotOffset).magnitude);
		if (playerController.IsAiming() &&  mag < 0.05f)
			GUI.DrawTexture(new Rect(Screen.width/2-(crosshair.width*0.5f), 
			                         Screen.height/2-(crosshair.height*0.5f), 
			                         crosshair.width, crosshair.height), crosshair);
	}



	// touch input
	private Vector2 getOrbitTouchMovement(){

		// nullify the orbitcam's movement touch if it is inactive
		if ((orbitTouchIndex > NULL_TOUCH_INDEX && orbitTouchIndex < Input.touchCount) &&
			(Input.GetTouch(orbitTouchIndex).phase == TouchPhase.Canceled || 
				Input.GetTouch(orbitTouchIndex).phase == TouchPhase.Ended)) {
			orbitTouchIndex = NULL_TOUCH_INDEX;
		}


		// get a new touch index from right side of screen 
		// only if the currentTouch is null
		if (orbitTouchIndex == NULL_TOUCH_INDEX) {
			for (int i = 0; i < Input.touchCount; i++) {
				Touch t = Input.GetTouch (i); 
				if (t.position.x > Screen.width / 2 && t.phase == TouchPhase.Began) {
					orbitTouchIndex = i;
					orbitTouchOrigin = t.position;
					break;
				}
			}
		}

		// return the touche's movement
		if (orbitTouchIndex > NULL_TOUCH_INDEX && orbitTouchIndex < Input.touchCount) {
			return Input.GetTouch (orbitTouchIndex).position - orbitTouchOrigin;
		}

		return Vector2.zero;
	}


}
