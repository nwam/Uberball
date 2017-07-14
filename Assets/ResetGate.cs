using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGate : MonoBehaviour {
	
	public void disableAllEffects(GameObject obj){
		Gate[] gates = GameObject.FindObjectsOfType<Gate> ();
		foreach (Gate gate in gates) {
			gate.disableEffect (obj);
			gate.killGUI ();
		}
	}

}
