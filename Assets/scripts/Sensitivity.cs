using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour {
	private const string SENSITIVITY_KEY = "mousesensitivity";
	private const float DEFAULT_SENSITIVITY = 400.0f;

	protected void setSensitivity(float sensitivity){
		PlayerPrefs.SetFloat (SENSITIVITY_KEY, sensitivity);
		GameObject.FindObjectOfType<ThirdPersonOrbitCam>().verticalAimingSpeed = sensitivity;
		GameObject.FindObjectOfType<ThirdPersonOrbitCam>().horizontalAimingSpeed = sensitivity;
	}

	protected float getSensitivity(){
		return PlayerPrefs.HasKey(SENSITIVITY_KEY) ? PlayerPrefs.GetFloat (SENSITIVITY_KEY) : DEFAULT_SENSITIVITY;
	}


}
