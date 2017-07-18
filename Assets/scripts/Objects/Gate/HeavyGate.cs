using UnityEngine;
using System.Collections;

public class HeavyGate : Gate {

	public float massMultiplier;

	protected override void effect(GameObject obj) {
		Rigidbody rb = obj.GetComponent<Rigidbody> ();
		rb.mass *= massMultiplier;
	}

	public override void disableEffect(GameObject obj) {
		Rigidbody rb = obj.GetComponent<Rigidbody> ();
		rb.mass /= massMultiplier;
	}


	protected override void setType(){
		type = EffectDisplay.EffectType.heavy;
	}
}
