using UnityEngine;
using System.Collections;

public class BouncePad : Pad {

	public float resetTime;
	private float lastEffect = 0;

	// Direction is always the local Y coordinate of the pad
	protected override void setDirection() {
		Transform t = GetComponent<Transform> ();
		direction = new Vector3 (
			-Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.z), 
			Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.z), 
			Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.x));
		direction.Normalize ();
	}

	public override void effect(GameObject player) {
		if (Time.time > lastEffect + resetTime) {
			lastEffect = Time.time;

			Rigidbody rb = player.GetComponent<Rigidbody> ();

			// constant bounce height
			Vector3 velocityYZero = rb.velocity;
			velocityYZero.y = 0;
			rb.velocity = velocityYZero;

			rb.AddForce (direction * power);

		}
	}
		
		
}
