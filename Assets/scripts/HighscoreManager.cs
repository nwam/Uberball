using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreManager : Singleton<HighscoreManager> {

	private const string HS_PREFIX = "hs";
	private const string HS_THUMB_PREFIX = "hsthumb";

	// Add score to highscores (if score is good enough)
	public int submitScore(int score) {
		string levelName = SceneManager.GetActiveScene ().name;

		// loop the level's highscores
		for (int i = 1; i <= 5; i++) {
			string iKey = levelName + HS_PREFIX + i.ToString ();
			string iThumbKey = levelName + HS_THUMB_PREFIX + i.ToString ();
			int highscore = PlayerPrefs.GetInt(iKey);

			// find the highest beaten score
			if (score > highscore || !PlayerPrefs.HasKey(iKey)) {
				// move the remaining scores down a position
				for (int j = 4; j >= i; j--) {
					if (PlayerPrefs.HasKey (levelName + HS_PREFIX + j.ToString ())) {
						PlayerPrefs.SetInt (levelName + HS_PREFIX + (j + 1).ToString (), PlayerPrefs.GetInt (levelName + HS_PREFIX + j.ToString ()));
					}
				}

				// replace the highest beaten score info with the new score info
				PlayerPrefs.SetInt(iKey, score);
				PlayerPrefs.SetString (iThumbKey, LoadCharacter.Instance.getCharacterName ());

				return i;
			}
		}

		return 0;
	}

	public int getHighscore(int position){
		string levelName = SceneManager.GetActiveScene ().name;
		string key = levelName + HS_PREFIX + position;

		return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt (key) : -999999;
	}

	public Texture getHighscoreThumbnail(int position){
		string levelName = SceneManager.GetActiveScene ().name;
		string hsLevelThumbPrefix = levelName + HS_THUMB_PREFIX;
		string characterName = PlayerPrefs.GetString (hsLevelThumbPrefix + position);
		return LoadCharacter.getCharacterThumbnail (characterName);
	}
		
}
