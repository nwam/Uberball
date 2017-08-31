using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTypeButtons : CameraType {

	public Button autoButton;
	public Button orbitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// used by button
	public void setOrbit(){
		setCameraType (CamType.orbit);
	}

	// used by button
	public void setAuto(){
		setCameraType (CamType.auto);
	}
}
