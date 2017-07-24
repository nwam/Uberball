using UnityEngine;
using System.Collections;

public class BouncePad : Pad {

	public float resetTime = 0.1f;
	private float lastEffect = 0;

	// Direction is always the local Y coordinate of the pad
	protected override void setDirection() {
		Transform t = GetComponent<Transform> ();
		float xrot = Mathf.Deg2Rad * t.rotation.eulerAngles.x;
		float yrot = Mathf.Deg2Rad * t.rotation.eulerAngles.y;
		float zrot = Mathf.Deg2Rad * t.rotation.eulerAngles.z;

		direction = new Vector3 (
			-Mathf.Sin (zrot) * Mathf.Cos (yrot) - Mathf.Sin (xrot) * Mathf.Sin (yrot),
			Mathf.Cos (xrot) * Mathf.Cos (zrot), 
			Mathf.Sin (xrot) * Mathf.Cos (yrot) + Mathf.Sin (zrot) * Mathf.Sin (yrot)); 
		
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
