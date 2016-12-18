using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	private ScoreController scoreController;
	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.FindObjectOfType<ScoreController> ();
		scoreText = GetComponent<Text> ();
		displayScoreText ();
	}

	// Update is called once per frame
	void LateUpdate () {
		displayScoreText ();
	}

	void displayScoreText() {
		scoreText.text = scoreController.getScore ().ToString ();
	}


}
