using UnityEngine;
using System.Collections;

public class BouncePad : Pad {

	// Direction is always the local Y coordinate of the pad
	public override void setDirection() {
		Transform t = GetComponent<Transform> ();
		direction = new Vector3 (
			-Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.z), 
			Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.z), 
			Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.x));
		direction.Normalize ();
	}
		
		
}
