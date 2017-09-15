using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreUnlocker : Unlocker {

	public int goalScore;

	void Start(){
		key = SceneManager.GetActiveScene ().name + "_score_" + goalScore;
	}

	public void maybeUnlock(int score){
		if (score >= goalScore) {
			unlock ();
		}
	}
}
