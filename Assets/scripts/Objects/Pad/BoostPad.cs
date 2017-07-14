using UnityEngine;
using System.Collections;

public class BoostPad : Pad {

	public float maxSpeedXZ;
	public float maxSpeedY;

	// direction is always the local -Z coordinate of the pad
	protected override void setDirection() {
		Transform t = GetComponent<Transform> ();
		direction = new Vector3 (
			-Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.y) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x), 
			Mathf.Sin (Mathf.Deg2Rad * t.eulerAngles.x), 
			-Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.y) * Mathf.Cos (Mathf.Deg2Rad * t.eulerAngles.x));
		direction.Normalize ();	
	}

	public override void effect(GameObject player) {
		Rigidbody rb = player.GetComponent<Rigidbody> ();
		rb.AddForce (direction * power);

		slowDown (player);

		//apply force
		//on second loop, slow down if going over speed
	
	/**	//max speed Y
		float speedY = (power * direction.y / rb.mass - Physics.gravity.y) / Time.fixedDeltaTime + rb.velocity.y;
		Vector3 velocityY = new Vector3 (0, maxSpeedY > 0 && speedY > maxSpeedY ? maxSpeedY : speedY, 0);

		//max speed XZ
		Vector3 directionXZ = new Vector3 (direction.x, 0, direction.z);
		Vector3 velocityXZ = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
		float speedXZ = (power * directionXZ.magnitude / rb.mass) / Time.fixedDeltaTime + velocityXZ.magnitude;

		float s; // speed coefficient
		if (directionXZ.magnitude > 0) { 
			if (maxSpeedXZ > 0 && speedXZ > maxSpeedXZ) {
				s = maxSpeedXZ*Time.fixedDeltaTime / (Mathf.Sqrt (directionXZ.magnitude));
			} else {
				s = speedXZ*Time.fixedDeltaTime / (Mathf.Sqrt (directionXZ.magnitude));
			}
		} else {
			s = 0;
		}

		velocityXZ = directionXZ * s;

		rb.velocity = velocityY;

		**/
	}

	public void slowDown(GameObject player) { 
		Rigidbody rb = player.GetComponent<Rigidbody> ();

		Vector3 v = rb.velocity;
		if (maxSpeedY>0 && v.y > maxSpeedY) {
			rb.velocity = new Vector3 (v.x, maxSpeedY, v.z);
		}

		Vector3 velocityXZ = new Vector3 (v.x, 0, v.z);
		if (maxSpeedXZ>0 && velocityXZ.magnitude > maxSpeedXZ) {
			velocityXZ = Vector3.ClampMagnitude (velocityXZ, maxSpeedXZ);
			rb.velocity = new Vector3 (velocityXZ.x, rb.velocity.y, velocityXZ.z);
		}
	}

}
