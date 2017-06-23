using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	protected InputManager inputManager;

	protected void Start() {
		inputManager = GameObject.FindGameObjectWithTag ("InputManager").GetComponent<InputManager> ();
		afterStart ();
	}

	protected virtual void afterStart(){
	}

	public void setAsActiveInputController() {
		inputManager.setActiveController (this);
	}
		
	public virtual void applyInput(){
	}

	public virtual void applyInputFixed(){
	}

	public virtual void disableInput() {
	}
}
