using UnityEngine;
using System.Collections;

public class PlayerCollideSound : MonoBehaviour {
	public AudioClip sound;

	void OnTriggerEnter(Collider col){
		GameObject obj = col.gameObject;

		if (obj.CompareTag ("Player")) {
			AudioSource.PlayClipAtPoint (sound, transform.position);	
		}
	}

}
