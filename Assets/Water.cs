using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
	public float drag = 0.5f;

	public void applyDrag(GameObject obj){
		obj.GetComponent<Collider>().attachedRigidbody.drag = drag;

		if (drag > 1.0f) {
			obj.GetComponent<PlayerController> ().setInWater (true);
		}else{
			obj.GetComponent<PlayerController> ().setInWater (false);
		}
	}
}
