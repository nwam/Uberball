using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockableComponent : MonoBehaviour {
	public string key;


	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey (key)) {
			gameObject.SetActive (false);
		}
	}
}
