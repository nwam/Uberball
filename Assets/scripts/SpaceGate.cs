﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGate : Gate {

	protected override void effect(GameObject obj) {
		Collider col = obj.GetComponent<Collider> ();
		col.attachedRigidbody.useGravity = false;
		obj.GetComponent<PlayerController> ().setInSpace (true);
	}

	public override void disableEffect(GameObject obj) {
		Collider col = obj.GetComponent<Collider> ();
		col.attachedRigidbody.useGravity = true;
		obj.GetComponent<PlayerController> ().setInSpace (false);
	}

	protected override void setType(){
		type = "space";
	}
}
