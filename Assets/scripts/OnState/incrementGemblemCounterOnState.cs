using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incrementGemblemCounterOnState : OnAnimatorState{

	protected override void actionOnState(){
		GameObject.FindObjectOfType<GemblemCounter> ().incrementDisplay ();
		enabled = false;
	}
}
