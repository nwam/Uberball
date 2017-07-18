using UnityEngine;
using System.Collections;

public class MagnetGate : Gate {

	public float radius;
	public float force;

	protected override void effect(GameObject obj) {
		Magnet magnet = GameObject.FindObjectOfType<Magnet> ();
		magnet.magnetize (radius, force);
	}

	public override void disableEffect(GameObject obj) {
		Magnet magnet = GameObject.FindObjectOfType<Magnet> ();
		magnet.demagnetize ();
	}

	protected override void setType(){
		type = EffectDisplay.EffectType.magnet;
	}
}
