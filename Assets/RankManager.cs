using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankManager : Singleton<RankManager> {
	private const float OLD_RANK_WAIT = 2.5f;
	private const int SCORE_DISPLAY_INCREASE_FRAMES = 500;
	private const float SCORE_DISPLAY_INCREASE_MAX = 3.5f;
	private const float SCORE_DISPLAY_INCREASE_MIN = 0.25f;
	private const string RANK_IDENTIFIER = "rank";

	public enum Rank {platinum, gold, silver, bronze, green, purple, blue, white};

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

	private int oldRecord;
	private int newRecord;
	private int currentScore;

	public Text scoreDisplay;
	private float scoreDisplayValue;
	private float scoreDisplayIncrease;
	private int rankDisplayIndex;
	private bool incrementScoreDisplay;

	public GameObject newRecordText;

	public GameObject overZeroGemblemAward;
	private const string START_OVER_ZERO = "ranksDone";

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
			notifyNextAnimation ();
		}
	}

	private IEnumerator runNewRecordAnimations(){
		int oldRank = getRankIndex (oldRecord);
		int newRank = getRankIndex (newRecord);

		scoreDisplayValue = (float) (oldRecord < rankBounds [(int)Rank.white] ? rankBounds [(int)Rank.white] : oldRecord);
		rankDisplayIndex = oldRank;

		scoreDisplayIncrease = Mathf.Max(
			SCORE_DISPLAY_INCREASE_MIN,
			Mathf.Min(
				SCORE_DISPLAY_INCREASE_MAX,
				(float)((float) (newRecord - oldRecord)) / SCORE_DISPLAY_INCREASE_FRAMES));


		// store new rank
		PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + RANK_IDENTIFIER, newRank);

		// enable rank objects that we will be using
		for (int rankIndex = oldRank; rankIndex >= newRank; rankIndex--) {
			rankObjects [rankIndex].SetActive (true);
		} 

		// enable the score display
		scoreDisplay.enabled = true;
		scoreDisplay.text = ((int) (scoreDisplayValue)).ToString ();
		newRecordText.SetActive (true);

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
			scoreDisplayValue = scoreDisplayValue + scoreDisplayIncrease;

			// check if new score (display) has been reached
			if (scoreDisplayValue >= newRecord) {
				scoreDisplayValue = (float) newRecord;
				rankObjects [rankDisplayIndex].GetComponent<Animator> ().SetBool ("scoreDoneIncrease", true);
				incrementScoreDisplay = false;
			} 

			scoreDisplay.text = ((int) (scoreDisplayValue)).ToString();
		}
	}

	private void notifyNextAnimation(){
		overZeroGemblemAward.GetComponent<Animator> ().SetBool (START_OVER_ZERO, true);
	}

	public static Rank getRank(string level){
		return (Rank)PlayerPrefs.GetInt (SceneManager.GetActiveScene ().name + RANK_IDENTIFIER);
	}
}
