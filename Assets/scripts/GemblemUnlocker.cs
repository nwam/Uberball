/*
 * Parent class for unlocking gemblems, 
 * there will be four missions in each level to unlock a gemblem
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class GemblemUnlocker : MonoBehaviour {

	private const int UNLOCK = 1;
	private const string GEMBLEM_PREFIX = "gemblem";
	private const string ANIMATOR_SHOW = "show";
	private const string ANIMATOR_SKIP = "skip";


	private string key;
	protected MissionType missionType;

	protected enum MissionType {LevelComplete, OverZeroPoints, Collector, HiddenTreasure};

	// Use this for initialization
	void Start () {
		key = SceneManager.GetActiveScene ().name + GEMBLEM_PREFIX + missionType;
		setMissionType ();
	}


	// returns true if it is the first time getting the gemblem
	private bool unlock() {

		if (!PlayerPrefs.HasKey (key)) {
			showAnimation ();
			return true;
		}

		PlayerPrefs.SetInt (key, UNLOCK);
		return false;
	}
		

	public void maybeUnlock(){
		bool first_time_unlocked = true;
		bool unlocked = false;

		if (unlockCondition ()) {
			first_time_unlocked = unlock ();
			unlocked = true;
		}

		if (!first_time_unlocked || !unlocked) {
			skipAnimation ();
		}
	}

	protected virtual bool unlockCondition(){
		return true;
	}
		
	protected virtual void setMissionType(){
	}

	private void skipAnimation(){
		GetComponent<Animator>().SetBool (ANIMATOR_SKIP, true);
	}

	private void showAnimation(){
		GetComponent<Animator>().SetBool (ANIMATOR_SHOW, true);
	}

}
