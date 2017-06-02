using UnityEngine;
using System.Collections;

// controls which inputController to apply the input to
public class InputManager : Singleton<InputManager> {

	private InputController activeController;
	private bool allowInput;

	// Update is called once per frame
	void Update () {
		// TODO : try catch?
		if (allowInput && activeController != null) {
			activeController.applyInput ();
		}
	}

	void FixedUpdate () {
		// TODO : try catch?
		if (allowInput && activeController != null) {
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


	public void enableInput(){
		allowInput = true;
	}

	public void disableInput(){
		allowInput = false;
	}


}
