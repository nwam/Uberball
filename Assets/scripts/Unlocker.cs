using UnityEngine;
using System.Collections;

public class Unlocker : MonoBehaviour {
	private const int UNLOCK = 1;

	public string[] keys;

	public void unlock(){
		foreach (string key in keys) {
			PlayerPrefs.SetInt (key, UNLOCK);
		}
	}
}
