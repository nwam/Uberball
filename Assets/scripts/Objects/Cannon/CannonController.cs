using UnityEngine;
using System.Collections;

public class CannonController : InputController {

	public float yRotationLimit;
	private float yRotationStart;

	private float h;
	private float v;

	private Cannon cannon;

	protected override void afterStart() {
		cannon = gameObject.transform.parent.Find ("CannonTrigger").GetComponent<Cannon> ();
		yRotationStart = transform.rotation.eulerAngles.y;
	}

	public override void applyInput() {

		// get input
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		// calculate new rotation
		float xRot = gameObject.transform.eulerAngles.x - v;
		float yRot = gameObject.transform.eulerAngles.y + h;

		// limit rotation
		if (xRot < 360 - 87.5 && xRot > 20) {
			if (xRot < 180) {
				xRot = 20.0f;
			} else {
				xRot = 360.0f - 87.5f;
			}
		}
		if (yRot < yRotationStart - yRotationLimit / 2) {
			yRot = yRotationStart - yRotationLimit / 2;
		} else if (yRot > yRotationStart + yRotationLimit / 2) {
			yRot = yRotationStart + yRotationLimit / 2;
		}

		// apply input to camera's transform
		gameObject.transform.rotation = Quaternion.Euler (
			xRot,
			yRot,
			0
		);
	}

	public override void applyInputFixed() {
		// fire cannon when jump is pressed
		if (Input.GetAxis ("Jump") != 0) {
			cannon.fire (gameObject.transform.position, transform.forward);
		}
	}

	// called when the InputController is no longer active
	public override void disableInput() {
		h = 0;
		v = 0;
	}

}
