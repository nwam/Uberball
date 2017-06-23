using UnityEngine;
using System.Collections;

public class BouncePowerup : Powerup {

	private float power = 800;

	protected override void setType(){
		type = "jump";
	}

	public override void effect (int powerLevel) {
		Rigidbody rb = collectedBy.GetComponent<Rigidbody> ();
		Vector3 upwardForce = new Vector3 (0, power * powerLevel - ((powerLevel-1) * power/3), 0);
		rb.AddForce (upwardForce);
	}
}
