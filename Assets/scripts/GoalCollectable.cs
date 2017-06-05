using UnityEngine;
using UnityEngine.SceneManagement;
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
		LevelManager.Instance.complete ();

		gameObject.SetActive (false);
		scoreController.stop ();

		// unlock unlockables
		if (goalUnlocker != null) {
			goalUnlocker.unlock (); 
		}

		// check if all gems collected
		string levelGemsCollected = SceneManager.GetActiveScene ().name + "_gems";
		if (!PlayerPrefs.HasKey(levelGemsCollected) && GameObject.FindGameObjectWithTag ("Points") == null) {
			PlayerPrefs.SetInt (levelGemsCollected, 1);
		}

		if (scoreUnlocker != null) {
			scoreUnlocker.check_score (scoreController.getScore ());
		}
			
		scoreController.submitScore ();
	}
}
