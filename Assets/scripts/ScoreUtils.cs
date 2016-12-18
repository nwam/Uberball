using UnityEngine;
using System.Collections;

public class ScoreUtils : MonoBehaviour {

	private string[] courseNames;
	private const string HS_PREFIX = "hs";
	private const int DEFAULT_SCORE = -999999;

	void Start(){
		courseNames = new string[]{"BobOmbBattlefield", "Test Course"};
	}

	public void resetScores() {
		foreach (string courseName in courseNames) {
			for (int i = 1; i <= 5; i++) {	
				PlayerPrefs.SetInt (courseName + HS_PREFIX + i.ToString (), DEFAULT_SCORE);
			}
		}
	}
}
