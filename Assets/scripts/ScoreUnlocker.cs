using UnityEngine;
using System.Collections;

public class ScoreUnlocker : Unlocker {

	public int goalScore;

	public void maybeUnlock(int score){
		if (score >= goalScore) {
			unlock ();
		}
	}
}
