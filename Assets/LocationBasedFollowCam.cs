using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationBasedFollowCam : Singleton<LocationBasedFollowCam> {

	public Transform player;
	public Vector2 cameraOffset;
	public Vector2 cameraRotation;

	void LateUpdate(){
		setCameraPos ();
		setCameraRot ();
	}

	private void setCameraPos(){
		transform.position = player.position + new Vector3(Mathf.Sin(cameraRotation.y/Mathf.Rad2Deg) * cameraOffset.x, 
														   cameraOffset.y, 
			Mathf.Cos(cameraRotation.y/Mathf.Rad2Deg) * cameraOffset.x);
	}

	private void setCameraRot(){
		transform.rotation = Quaternion.Euler (new Vector3(cameraRotation.x, cameraRotation.y, 0));
	}

}
