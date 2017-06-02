using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsText : MonoBehaviour {
	public string playerPref;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey (playerPref)) {
			gameObject.GetComponent<Text> ().text = PlayerPrefs.GetInt (playerPref).ToString ();
		}			
	}
}
