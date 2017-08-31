using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraType : MonoBehaviour {

	public enum CamType {auto, orbit};

	private const string CAMTYPE_KEY = "cameratype";
	private const CamType DEFAULT_CAMTYPE = CamType.auto;

	protected void setCameraType(CamType ct){
		PlayerPrefs.SetInt (CAMTYPE_KEY, (int)ct);

		switch (ct) 
		{
		case CamType.auto:
			LocationBasedFollowCam.Instance.enabled = true;
			ThirdPersonOrbitCam.Instance.enabled = false;
			break;

		case CamType.orbit:
			ThirdPersonOrbitCam.Instance.enabled = true;
			LocationBasedFollowCam.Instance.enabled = false;
			break;
		}
	}

	protected CamType getCameraType(){
		return PlayerPrefs.HasKey(CAMTYPE_KEY) ? (CamType)PlayerPrefs.GetInt (CAMTYPE_KEY) : DEFAULT_CAMTYPE;
	}

}
