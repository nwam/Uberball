﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalCollectable : MonoBehaviour {

	GoalUnlocker[] goalUnlockers;
	ScoreUnlocker[] scoreUnlockers;

	// Use this for initialization
	void Start () {
		goalUnlockers = GetComponents<GoalUnlocker> ();
		scoreUnlockers = GetComponents<ScoreUnlocker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getCollected() {
		LevelManager.Instance.complete ();

		gameObject.SetActive (false);

		// unlock unlockables
		foreach (GoalUnlocker goalUnlocker in goalUnlockers){
			goalUnlocker.unlock (); 
		}
		foreach (ScoreUnlocker scoreUnlocker in scoreUnlockers){
			scoreUnlocker.maybeUnlock (ScoreController.Instance.getScore ());
		}
	}
}
