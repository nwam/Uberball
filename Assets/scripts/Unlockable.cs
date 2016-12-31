using UnityEngine;
using System.Collections;

public class Unlockable : MonoBehaviour {
	public string[] keyHoles;
	public string name;
	public string type;
	public Texture image;
	private string promptKey;

	private const string PROMPT_KEY_PREFIX = "prompt_";

	void Start(){
		promptKey = PROMPT_KEY_PREFIX + type + "_" + name;

		// enable unlock if unlocked
		if (!has_keys ()) {
			gameObject.SetActive (false); 
		} else {

			// display new unlock prompt
			if (!PlayerPrefs.HasKey (promptKey)) {
				PlayerPrefs.SetInt (promptKey, 1);
				GameObject.FindObjectOfType<MainMenuUtils> ().displayUnlockPrompt (name, type, image);
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
