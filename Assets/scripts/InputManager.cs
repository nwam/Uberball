using UnityEngine;
using System.Collections;

// controls which inputController to apply the input to
public class InputManager : MonoBehaviour {

	private InputController activeController;


	// Update is called once per frame
	void Update () {
		// TODO : try catch?
		if (activeController != null) {
			activeController.applyInput ();
		}
	}

	void FixedUpdate () {
		// TODO : try catch?
		if (activeController != null) {
			activeController.applyInputFixed ();
		}
	}
		
	public void setActiveController(InputController i){
		// disable current controller
		if (activeController != null) {
			activeController.disableInput ();
		}

		// set new controller
		activeController = i;
	}
}
