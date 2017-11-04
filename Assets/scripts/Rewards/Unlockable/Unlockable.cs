using UnityEngine;
using System.Collections;

public class Unlockable : MonoBehaviour {
	public string[] keyHoles;
	public string[] unlockPromptConditions;
	public string unlockPromptName;
	protected string unlockPromptType;
	public Texture image;

	private string promptKey;

	private const string PROMPT_KEY_PREFIX = "prompt_";

	void Start(){
		setType ();
		promptKey = PROMPT_KEY_PREFIX + unlockPromptType + "_" + unlockPromptName;

		// enable unlock if unlocked
		if (!has_keys ()) {
			disable ();
		} else {

			// display new unlock prompt
			if (!PlayerPrefs.HasKey (promptKey)) {
				PlayerPrefs.SetInt (promptKey, 1);
				UnlockPrompt.Instance.maybeDisplay (unlockPromptName, unlockPromptType, unlockPromptConditions, image);
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

	protected virtual void setType(){
		unlockPromptType = "Stage";
	}

	protected virtual void disable(){
		gameObject.SetActive (false);
	}
}
