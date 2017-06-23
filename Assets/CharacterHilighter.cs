using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHilighter : MonoBehaviour {

	void OnEnable(){
		moveToSelectedCharacter ();
	}

	private void moveToSelectedCharacter(){
		string selectedCharacterName = PlayerPrefs.GetString (MainMenuUtils.SELECTED_CHARACTER);
		transform.position = transform.parent.Find (selectedCharacterName).Find ("img").position;
	}

}
