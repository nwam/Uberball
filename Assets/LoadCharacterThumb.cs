using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacterThumb : MonoBehaviour {

	void OnEnable(){
		string characterName = PlayerPrefs.GetString (MainMenuUtils.SELECTED_CHARACTER);
		GetComponent<RawImage> ().texture = LoadCharacter.getCharacterThumbnail (characterName);
	}
}
