using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalCollectable : MonoBehaviour {

	GoalUnlocker goalUnlocker;
	ScoreUnlocker scoreUnlocker;

	// Use this for initialization
	void Start () {
		goalUnlocker = GetComponent<GoalUnlocker> ();
		scoreUnlocker = GetComponent<ScoreUnlocker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getCollected() {
		LevelManager.Instance.complete ();

		gameObject.SetActive (false);
		ScoreController.Instance.stop ();

		// unlock unlockables
		if (goalUnlocker != null) {
			goalUnlocker.unlock (); 
		}


		if (scoreUnlocker != null) {
			scoreUnlocker.check_score (ScoreController.Instance.getScore ());
		}

		ScoreController.Instance.submitScore ();

		// check if all gems collected
		// TODO: move to another class, this doesnt belong here
		string levelGemsCollected = SceneManager.GetActiveScene ().name + "_gems";
		if (!PlayerPrefs.HasKey(levelGemsCollected) && GameObject.FindGameObjectWithTag ("Points") == null) {
			PlayerPrefs.SetInt (levelGemsCollected, 1);
		}
	}
}
