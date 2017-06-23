using UnityEngine;
using System.Collections;

public class Unlocker : MonoBehaviour {
	private const int UNLOCK = 1;

	public string key;

	public void unlock(){
			PlayerPrefs.SetInt (key, UNLOCK);
	}
}
