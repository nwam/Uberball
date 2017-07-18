using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGate : Gate {

	public Vector3 gravity;
	
	protected override void effect(GameObject obj) {
		// disables all other gravity effects
		GravityGate[] gravityGates = GameObject.FindObjectsOfType<GravityGate>();
		foreach (GravityGate gravityGate in gravityGates) {
			gravityGate.disableEffect (obj);
			gravityGate.killGUI ();
		}

		// change gravity
		Physics.gravity = gravity;
	}

	public override void disableEffect(GameObject obj) {
		Physics.gravity = new Vector3(0, -9.8f, 0);
	}

	protected override void setType(){
		type = EffectDisplay.EffectType.space;
	}
}