using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private int score;
	private bool subtractFromTime;
	private HighscoreManager highscoreManager;
	private HighscoreTable highscoreTable;


	// Use this for initialization
	void Start () {
		score = 0;
		subtractFromTime = true;
		highscoreManager = GameObject.FindObjectOfType<HighscoreManager> ();
		highscoreTable = GameObject.FindObjectOfType<HighscoreTable> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (subtractFromTime) {
			timeUpdate ();
		}
	}

	void timeUpdate() {
		score--;
	}

	public int getScore() {
		return score;
	}

	public void addScore(int amount) {
		score += amount;
	}

	public void stop() {
		subtractFromTime = false;
	}

	public void resume(){
		subtractFromTime = true;
	}

	public void submitScore() {
		int newHighscore = highscoreManager.submitScore (score);	
		highscoreTable.show ();
		if (newHighscore >= 1 && newHighscore <= 5) {
			highscoreTable.hilight (newHighscore);
		}
	}



}
