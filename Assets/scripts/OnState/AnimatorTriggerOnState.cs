using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerOnState : OnAnimatorState {

	public Animator animator;
	public string triggerParameterName;
	public string onState;

	// Update is called once per frame
	protected override void actionOnState () {
		if(animator != null){
			animator.SetTrigger (triggerParameterName);
		}
	}

}
