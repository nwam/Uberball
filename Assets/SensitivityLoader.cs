using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityLoader : Sensitivity {

	void Start(){
		setSensitivity (getSensitivity());
	}
}
