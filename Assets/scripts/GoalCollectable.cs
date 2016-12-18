using UnityEngine;
using System.Collections;

public class GoalCollectable : MonoBehaviour {

	ScoreController scoreController;
	GoalUnlocker goalUnlocker;
	ScoreUnlocker scoreUnlocker;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.FindObjectOfType<ScoreController> ();
		goalUnlocker = GetComponent<GoalUnlocker> ();
		scoreUnlocker = GetComponent<ScoreUnlocker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getCollected() {
		gameObject.SetActive (false);
		scoreController.stop ();

		// unlock unlockables
		if (goalUnlocker != null) {
			goalUnlocker.unlock (); 
		}
		if (scoreUnlocker != null) {
			scoreUnlocker.check_score (scoreController.getScore ());
		}
			
		scoreController.submitScore ();
	}
}
