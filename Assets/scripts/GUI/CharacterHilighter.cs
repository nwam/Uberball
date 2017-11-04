using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHilighter : MonoBehaviour {

	void OnEnable(){
		StartCoroutine (lateOnEnable ());
	}

	private IEnumerator lateOnEnable(){
		yield return new WaitForSecondsRealtime (0.1f);
		moveToSelectedCharacter ();
	}

	private void moveToSelectedCharacter(){
		string selectedCharacterName = PlayerPrefs.HasKey(MainMenuUtils.SELECTED_CHARACTER) ? 
			PlayerPrefs.GetString (MainMenuUtils.SELECTED_CHARACTER) : 
			"null";
		transform.position = transform.parent.Find (selectedCharacterName).Find ("img").position;
	}

}
