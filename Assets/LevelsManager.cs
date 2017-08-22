using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsManager : Singleton<LevelsManager> {

	public static string[] levels = new string[5] {
		"TheTree",
		"BouncyCliffs",
		"Dragrace1",
		"Gates",
		"Seasick"
	};

	private int currentLevelIndex;
	private bool hasNextLevel;

	void Start(){
		string currentLevelName = SceneManager.GetActiveScene ().name;
		for (int i=0; i<levels.Length; i++){
			if (string.Equals (levels [i], currentLevelName, System.StringComparison.OrdinalIgnoreCase)) {
				currentLevelIndex = i;
				break;
			}
		}
		hasNextLevel = currentLevelIndex + 1 >= levels.Length ? false : true;
	}
		
	public void startNextLevel(){
		if (hasNextLevel) {
			SceneManager.LoadScene (levels [currentLevelIndex + 1]);
		}
	}
}
