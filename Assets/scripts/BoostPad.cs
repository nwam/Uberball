using UnityEngine;
using System.Collections;

public class BoostPad : Pad {

	// direction is always the local -Z coordinate of the pad
	public override void setDirection() {
		Transform t = GetComponent<Transform> ();
		direction = new Vector3 (
			-Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.y) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x), 
			Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.x), 
			-Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.y) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x));
		direction.Normalize ();
	}

}
