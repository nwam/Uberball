using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamModifier : MonoBehaviour {
	private LocationBasedFollowCam cam;

	private float startTime;
	public float duration;

	public bool animating = false;

	private Vector2 startCameraOffset;
	private Vector2 startCameraRotation;
	public Vector2 endCameraOffset;
	public Vector2 endCameraRotation;

		
	void Update(){
		if (animating) {
			float t = (Time.time - startTime) / duration;
			cam.cameraOffset = new Vector2 (Mathf.SmoothStep (startCameraOffset.x, endCameraOffset.x, t),
				Mathf.SmoothStep (startCameraOffset.y, endCameraOffset.y, t));
			cam.cameraRotation = new Vector2 (Mathf.SmoothStep (startCameraRotation.x, endCameraRotation.x, t),
				Mathf.SmoothStep (startCameraRotation.y, endCameraRotation.y, t));

			if (t >= 1) {
				animating = false;
			}
		}
	}

	public void animateCamera(){
		foreach (FollowCamModifier fcm in GameObject.FindObjectsOfType<FollowCamModifier>()){
			if (this != fcm) {
				fcm.animating = false;
			}
		}

		cam = LocationBasedFollowCam.Instance;

		startCameraOffset = cam.cameraOffset;
		startCameraRotation = cam.cameraRotation;

		startTime = Time.time;

		animating = true;
	}

}
