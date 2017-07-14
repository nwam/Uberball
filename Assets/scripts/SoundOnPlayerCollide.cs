using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnPlayerCollide : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		GameObject obj = col.gameObject;

		if (obj.CompareTag ("Player")) {
			gameObject.GetComponent<AudioSource> ().Play();
		}
	}
}
