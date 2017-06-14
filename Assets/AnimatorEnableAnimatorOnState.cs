using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEnableAnimatorOnState : OnAnimatorState {

	public Animator animatorToEnable;

	protected override void actionOnState(){
		animatorToEnable.enabled = true; 
	}
}
