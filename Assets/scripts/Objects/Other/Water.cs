using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
	private float airDrag = 0.5f;
	private float waterDrag = 5.0f;

	public void applyDrag(GameObject obj){

		// if the object is underwater
		if (obj.transform.position.y < transform.position.y) {
			obj.GetComponent<PlayerController> ().setInWater (true);
			obj.GetComponent<Collider> ().attachedRigidbody.drag = waterDrag;
		}else{
			obj.GetComponent<PlayerController> ().setInWater (false);
			obj.GetComponent<Collider> ().attachedRigidbody.drag = airDrag;
		}
	}
}
