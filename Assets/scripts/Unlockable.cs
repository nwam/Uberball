using UnityEngine;
using System.Collections;

public class Unlockable : MonoBehaviour {
	public string[] keyHoles;
	public string promptKey;

	void Start(){

		if (!has_keys ()) {
			gameObject.SetActive (false); 
		} else {
			if (!PlayerPrefs.HasKey (promptKey)) {
				PlayerPrefs.SetInt (promptKey, 1);
				// TODO: display prompt
			}
		}
	}

	private bool has_keys(){
		// check if we have a key for every key hole
		foreach (string keyHole in keyHoles) {
			if (!PlayerPrefs.HasKey (keyHole)) {
				return false;
			}
		}

		return true;
	}
}
