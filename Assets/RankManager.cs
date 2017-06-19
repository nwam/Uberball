using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : Singleton<RankManager> {
	private const float OLD_RANK_WAIT = 2.5f;
	private const int SCORE_DISPLAY_INCREASE = 1;

	private enum Rank {platinum, gold, silver, bronze, green, purple, blue, white};

	private GameObject[] rankObjects;
	private int[] rankBounds;
	public int platinum;
	public int gold;
	public int silver;
	public int bronze;
	public int green;
	public int purple;
	public int blue;
	public int white;

	public Text scoreDisplay;
	private int scoreDisplayValue;
	private int rankDisplayIndex;

	private int oldRecord;
	private int newRecord;
	private int currentScore;
	private bool incrementScoreDisplay;

	public Animator nextAnimation;

	// Use this for initialization
	void Start () {
		rankBounds = new int[8] {
			platinum,
			gold,
			silver,
			bronze,
			green,
			purple,
			blue,
			white
		};
			
		rankObjects = new GameObject[8] {
			transform.Find(Rank.platinum.ToString()).gameObject,
			transform.Find(Rank.gold.ToString()).gameObject,
			transform.Find(Rank.silver.ToString()).gameObject,
			transform.Find(Rank.bronze.ToString()).gameObject,
			transform.Find(Rank.green.ToString()).gameObject,
			transform.Find(Rank.purple.ToString()).gameObject,
			transform.Find(Rank.blue.ToString()).gameObject,
			transform.Find(Rank.white.ToString()).gameObject
		};
	
		incrementScoreDisplay = false;
		StartCoroutine (lateStart());
	}

	private IEnumerator lateStart(){
		yield return new WaitForSecondsRealtime (0.1f);
		oldRecord = HighscoreManager.Instance.getHighscore (1);
	}



	private int getRankIndex(int score){
		int rankIndex = 0;
		while (rankIndex < rankBounds.Length && score < rankBounds [rankIndex]) {
			rankIndex++;
		}
		return rankIndex < rankObjects.Length ? rankIndex : rankObjects.Length - 1;
	}

	private bool gotNewRecord(){
		currentScore = ScoreController.Instance.getScore ();
		if (currentScore > oldRecord && currentScore > rankBounds [(int)Rank.white]) {
			newRecord = currentScore;
			return true;
		}
		return false;
	}




	// ------ ANIMATION THINGS -----

	public void maybeRunAnimations(){
		if (gotNewRecord ()) {
			StartCoroutine (runNewRecordAnimations ());
		} else {
			nextAnimation.enabled = true;
		}
	}

	private IEnumerator runNewRecordAnimations(){
		int oldRank = getRankIndex (oldRecord);
		int newRank = getRankIndex (newRecord);

		scoreDisplayValue = oldRecord < rankBounds [(int)Rank.white] ? rankBounds [(int)Rank.white] : oldRecord;
		rankDisplayIndex = oldRank;

		// enable rank objects that we will be using
		for (int rankIndex = oldRank; rankIndex >= newRank; rankIndex--) {
			rankObjects [rankIndex].SetActive (true);
		} 

		// unlock over-zero gemblem
		if (oldRecord < 0 && newRecord >= 0) {
			rankObjects [(int)Rank.bronze].GetComponent<GemblemOverZeroUnlocker> ().maybeUnlock ();
			rankObjects [newRank].GetComponent<Animator> ().SetBool ("gemblemOverZeroAwarded", true);
		}

		// enable the score display as well
		scoreDisplay.enabled = true;
		scoreDisplay.text = scoreDisplayValue.ToString ();

		// start by displaying the old rank for a few seconds
		rankObjects[rankDisplayIndex].GetComponent<Animator>().SetBool("oldRank", true);
		rankObjects[rankDisplayIndex].GetComponent<Animator>().SetBool("in", true);
		yield return new WaitForSecondsRealtime (OLD_RANK_WAIT);
		rankObjects[rankDisplayIndex].GetComponent<Animator> ().SetBool ("scoreIncrease", true);

		// begin increasing the score
		// let Update() do the work from here
		incrementScoreDisplay = true;

	}
		
	// Update is called once per frame
	void Update () {
		if (incrementScoreDisplay) {
			// check if new rank has been reached
			if (rankDisplayIndex > 0 && rankBounds [rankDisplayIndex - 1] <= scoreDisplayValue) {
				// kill current rank object
				rankObjects[rankDisplayIndex].GetComponent<Animator>().SetBool("kill", true);

				// enable the new rank object
				--rankDisplayIndex;
				rankObjects [rankDisplayIndex].GetComponent<Animator> ().SetBool ("scoreIncrease", true);
				rankObjects [rankDisplayIndex].GetComponent<Animator> ().SetBool ("in", true);
			}

			// increment score
			scoreDisplayValue = scoreDisplayValue + SCORE_DISPLAY_INCREASE;

			// check if new score (display) has been reached
			if (scoreDisplayValue >= newRecord) {
				scoreDisplayValue = newRecord;
				rankObjects [rankDisplayIndex].GetComponent<Animator> ().SetBool ("scoreDoneIncrease", true);
				incrementScoreDisplay = false;
			} 

			scoreDisplay.text = scoreDisplayValue.ToString();
		}
	}
}
