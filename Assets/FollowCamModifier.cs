using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamModifier : MonoBehaviour {
	private LocationBasedFollowCam cam;
	private bool commence;
	private bool modifyingCamera;

	private float startTime;
	public float duration;

	private Vector2 startCameraOffset;
	private Vector2 startCameraRotation;
	public Vector2 endCameraOffset;
	public Vector2 endCameraRotation;


	void Start(){
		cam = LocationBasedFollowCam.Instance;
		commence = false;
		modifyingCamera = false;

		startCameraOffset = cam.cameraOffset;
		startCameraRotation = cam.cameraRotation;
	}
		
	void Update(){
		if (commence) {
			startTime = Time.time;
			commence = false;
			modifyingCamera = true;
		}

		if (modifyingCamera) {
			float t = (Time.time - startTime) / duration;
			cam.cameraOffset = new Vector2 (Mathf.SmoothStep (startCameraOffset.x, endCameraOffset.x, t),
				                            Mathf.SmoothStep (startCameraOffset.y, endCameraOffset.y, t));
			cam.cameraRotation = new Vector2 (Mathf.SmoothStep (startCameraRotation.x, endCameraRotation.x, t),
									          Mathf.SmoothStep (startCameraRotation.y, endCameraRotation.y, t));
		}
	}

	public void modifyCamera(){
		commence = true;
	}

}
