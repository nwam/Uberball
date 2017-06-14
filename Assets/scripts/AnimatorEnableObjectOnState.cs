using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnableObjectOnState : OnAnimatorState {

	public GameObject objectToEnable;

	protected override void actionOnState(){
		objectToEnable.SetActive (true);
	}

}
