using UnityEngine;
using System.Collections;

public class BounceGate : Gate {

	protected override void effect(GameObject obj) {
		Collider col = obj.GetComponent<Collider> ();
		PhysicMaterial bounceMaterial = (PhysicMaterial)Resources.Load ("player_bounce") as PhysicMaterial;
		col.material = bounceMaterial;
	}

	public override void disableEffect(GameObject obj) {
		Collider col = obj.GetComponent<Collider> ();
		PhysicMaterial ogPlayerPhysics = (PhysicMaterial)Resources.Load ("player_physics") as PhysicMaterial;
		col.material = ogPlayerPhysics;
	}

	protected override void setType(){
		type = "boing";
	}

}
