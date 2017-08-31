using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTypeLoader : CameraType {

	// Use this for initialization
	void Start () {
		setCameraType (getCameraType ());
	}
}
