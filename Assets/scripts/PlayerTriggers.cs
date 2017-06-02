using UnityEngine;
using System.Collections;

// controls what happens when player interacts with trigger objects
public class PlayerTriggers : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		GameObject obj = col.gameObject;

		if (obj.CompareTag ("Points")) {
			PointsCollectable pointsCollectable = obj.GetComponent<PointsCollectable>();
			pointsCollectable.getCollected ();
		}

		if (obj.CompareTag ("Gate")) {
			Gate gate = obj.GetComponent<Gate> ();
			gate.enableEffect (gameObject);
		}

		if (obj.CompareTag ("Powerup")) {
			Powerup powerup = obj.GetComponent<Powerup> ();
			powerup.getCollected (gameObject);
		}

		if (obj.CompareTag ("Switch")) {
			Switch switchButton = obj.GetComponent<Switch>();
			switchButton.activate ();
		}

		if (obj.CompareTag ("Cannon")) {
			Cannon cannon = obj.GetComponent<Cannon> ();
			cannon.enterCannon (gameObject);
		}

		if (obj.CompareTag ("Goal")) {
			GoalCollectable goalCollectable = obj.GetComponent<GoalCollectable> ();
			goalCollectable.getCollected ();
		}

		if (obj.CompareTag ("Respawn")) {
			LevelManager levelManager = (LevelManager)GameObject.FindObjectOfType<LevelManager> ();
			levelManager.softReset ();
		}

		if (obj.CompareTag ("DescretePad")) { 
			Pad pad = obj.GetComponent<Pad> ();
			pad.effect (gameObject);
		}

	}

	void OnTriggerStay(Collider col) {
		GameObject obj = col.gameObject;

		// pads act continuously
		if (obj.CompareTag ("ContinuousPad")) {
			Pad pad = obj.GetComponent<Pad> ();
			pad.effect (gameObject);
		}
	}

	void OnTriggerLeave(Collider col){
		GameObject obj = col.gameObject;

		// pads act continuously
		if (obj.CompareTag ("ContinuousPad")) {
			BoostPad pad = obj.GetComponent<BoostPad> ();
			pad.slowDown (gameObject);
		}
	}

}