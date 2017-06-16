using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorBoolOnState : OnAnimatorState {

	public Animator animator;
	public string boolParameterName;
	public bool value;

	// Update is called once per frame
	protected override void actionOnState () {
		if(animator != null){
			animator.SetBool (boolParameterName, value);
		}
	}
}
