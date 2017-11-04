using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableCharacter : Unlockable {

	protected override void setType(){
		unlockPromptType = "Character";
	}

	protected override void disable(){
		transform.Find ("img").gameObject.SetActive (false);
		transform.Find ("text").gameObject.SetActive (false);
	}
}
