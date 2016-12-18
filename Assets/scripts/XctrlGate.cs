using UnityEngine;
using System.Collections;

public class XctrlGate : Gate {
	private InputController ogController;
	private InputController noController;

	protected override void effect(GameObject obj) {
		// get the current controller and the null controller 
		ogController = obj.GetComponent<InputController> ();
		noController = gameObject.GetComponent<InputController> ();

		// set the null controller as active
		noController.setAsActiveInputController();

	}

	public override void disableEffect(GameObject obj) {
		// set the original controller as active
		ogController.setAsActiveInputController();
	}

	protected override void setType(){
		type = "xctrl";
	}

}
