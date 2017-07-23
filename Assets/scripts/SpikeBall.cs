using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour {

	public float pushForce;
	public int pointLoss;

	private GameObject deltaScoreDisplay;

	private float resetTime = 0.05f;
	private float resetTimer;
	private bool collidable = true;

	void Start(){
		deltaScoreDisplay = transform.parent.Find ("DeltaScoreDisplayContainer").gameObject;
	}

	public void collide (GameObject obj) {

		if (collidable) {
			ScoreController.Instance.addScore (-pointLoss);
			pushAway (obj);
			activateDeltaScoreDisplay (obj);

			collidable = false;
			resetTimer = resetTime;
		}


	}

	private void pushAway(GameObject obj){
		// push in direction of sphere normal collision point
		Vector3 direction = obj.transform.position - transform.position;
		direction.Normalize ();

		obj.GetComponent<Rigidbody> ().AddForce (direction * pushForce);
	}

	private void activateDeltaScoreDisplay(GameObject obj){
		deltaScoreDisplay.SetActive (false);
		deltaScoreDisplay.SetActive (true);
	}



	void FixedUpdate(){
		if (!collidable) {
			resetTimer -= Time.fixedDeltaTime;

			if (resetTimer < 0) {
				collidable = true;
			}
		}
	}
}
