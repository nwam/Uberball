using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// plays a sound when the player collides and this object gets disabled from the collision
// example: collectable gem which becomes inactive upon being collected
public class SoundOnPlayerCollideAndDisable : MonoBehaviour {

	public GameObject soundObject;

	void OnTriggerEnter(Collider col){
		GameObject obj = col.gameObject;

		if (obj.CompareTag ("Player")) {
			GameObject.Instantiate (soundObject).GetComponent<AudioSource> ().Play ();
		}
	}
}
