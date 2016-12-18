using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreTable : MonoBehaviour {

	private const string HS_PREFIX = "hs"; //sketchy, this is also in HighscoreManager
	private const string TITLE_WIN_TEXT = "NEW HIGHSCORE!";

	public Text title;
	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;
	private Image darken;

	void Start() {
		darken = GameObject.Find ("Canvas/Darken").GetComponent<Image> ();
	}


	// sets the text of the highscore table based on the highscores
	private void setText(){
		// Highscores per level are stored at <LevelName><HS_PREFIX><scoreNumer>
		string hsLevelPrefix = SceneManager.GetActiveScene ().name + HS_PREFIX;
		score1.text = "1 " + PlayerPrefs.GetInt (hsLevelPrefix + 1).ToString().PadLeft(7,' ');
		score2.text = "2 " + PlayerPrefs.GetInt (hsLevelPrefix + 2).ToString().PadLeft(7,' ');
		score3.text = "3 " + PlayerPrefs.GetInt (hsLevelPrefix + 3).ToString().PadLeft(7,' ');
		score4.text = "4 " + PlayerPrefs.GetInt (hsLevelPrefix + 4).ToString().PadLeft(7,' ');
		score5.text = "5 " + PlayerPrefs.GetInt (hsLevelPrefix + 5).ToString().PadLeft(7,' ');
	}
		
	public void show() {
		setText ();
		title.enabled = true;
		score1.enabled = true;
		score2.enabled = true;
		score3.enabled = true;
		score4.enabled = true;
		score5.enabled = true;
		darken.enabled = true;
	}

	public void hilight(int n){
		// change title text
		title.text = TITLE_WIN_TEXT;

		// hilight title text
		title.GetComponent<TextLerp>().enabled = true;

		//hilight the new score's text
		switch (n) {
		case 1:
			score1.GetComponent<TextLerp> ().enabled = true;
			break;
		case 2:
			score2.GetComponent<TextLerp> ().enabled = true;
			break;
		case 3:
			score3.GetComponent<TextLerp> ().enabled = true;
			break;
		case 4:
			score4.GetComponent<TextLerp> ().enabled = true;
			break;
		case 5:
			score5.GetComponent<TextLerp> ().enabled = true;
			break;
		}
	}
}
	