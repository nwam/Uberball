using UnityEngine;
using System.Collections;

public class ScoreUnlocker : Unlocker {

	public int goal_score;

	public void check_score(int score){
		if (score >= goal_score) {
			unlock ();
		}
	}
}
