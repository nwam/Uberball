using UnityEngine;
using System.Collections;

public class ScoreController : Singleton<ScoreController> {

	private int score;
	private bool subtractFromTime;
	private bool freezeScore;
	private HighscoreManager highscoreManager;
	private HighscoreTable highscoreTable;


	// Use this for initialization
	void Start () {
		score = 0;
		subtractFromTime = false;
		freezeScore = false;
		highscoreManager = GameObject.FindObjectOfType<HighscoreManager> ();
		highscoreTable = GameObject.FindObjectOfType<HighscoreTable> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

	public void resetScore() {
		score = 0;
	}

	public void addScore(int amount) {
		if (!freezeScore) {
			score += amount;
		}
	}

	public void stop() {
		subtractFromTime = false;
	}

	public void resume(){
		subtractFromTime = true;
	}

	public void freeze(){
		freezeScore = true;
	}

	public void submitScore() {
		Logger.log ("score " + score);
		int newHighscore = highscoreManager.submitScore (score);	
		highscoreTable.setScores ();
		if (newHighscore >= 1 && newHighscore <= 5) {
			highscoreTable.hilight (newHighscore);
		}

	}

}
