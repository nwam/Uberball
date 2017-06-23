using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHilighter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (lateStart ());
	}

	private IEnumerator lateStart(){
		yield return new WaitForSeconds (0.2f);
		string selectedCharacterName = PlayerPrefs.GetString (MainMenuUtils.SELECTED_CHARACTER);
		transform.position = transform.parent.Find (selectedCharacterName).Find("img").position;
	}

}
