using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreManager : MonoBehaviour {

	private const string HS_PREFIX = "hs";

	// Add score to highscores (if score is good enough)
	public int submitScore(int score) {
		string levelName = SceneManager.GetActiveScene ().name;

		// loop the level's highscores
		for (int i = 1; i <= 5; i++) {
			string iKey = levelName + HS_PREFIX + i.ToString ();
			int highscore = PlayerPrefs.GetInt(iKey);

			// find the highest beaten score
			if (score > highscore || !PlayerPrefs.HasKey(iKey)) {
				// move the remaining scores down a position
				for (int j = 4; j >= i; j--) {
					if (PlayerPrefs.HasKey (levelName + HS_PREFIX + j.ToString ())) {
						PlayerPrefs.SetInt (levelName + HS_PREFIX + (j + 1).ToString (), PlayerPrefs.GetInt (levelName + HS_PREFIX + j.ToString ()));
					}
				}

				// replace the highest beaten score with score
				PlayerPrefs.SetInt(iKey, score);
				return i;
			}
		}

		return 0;
	}
		
}
