using UnityEngine;
using System.Collections;

public class BoostPowerup : Powerup {

	private float power = 1000f;
	private float powerPower = 1.2f;

	protected override void setType(){
		type = "boost";
	}

	public override void effect (int powerLevel) {
		Rigidbody rb = collectedBy.GetComponent<Rigidbody> ();
		Vector3 boostForce = collectedBy.GetComponent<PlayerController> ().velocity.normalized * power * Mathf.Pow(powerLevel, powerPower);
		rb.AddForce (boostForce);
	}
}
