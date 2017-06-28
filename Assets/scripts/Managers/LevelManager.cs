using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Singleton<LevelManager> {

	private const string RESTART_KEY = "5";
	private const string MENU_KEY = "0";
	private const KeyCode PAUSE_KEY = KeyCode.Escape;

	private const float TIME_SCALE = 1.5f;

	public GameObject pauseMenu;

	public enum GameState { 
		intro,
		countdown,
		playing,
		paused,
		complete
	};

	public GameState gameState { get; set;}

	void Start() {
		gameState = GameState.countdown;//should be intro
		Time.timeScale = TIME_SCALE;
	}
		
	void FixedUpdate () {
		// reset game
		if (Input.GetKey (RESTART_KEY)) {
			hardReset ();		
		}
		if (Input.GetKey (MENU_KEY)) {
			mainMenu ();
		}
		if (Input.GetKey (PAUSE_KEY)) {
			pause ();
		}
	}




	// Resets the current level
	public void hardReset(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// goes to main menu
	public void mainMenu() {
		SceneManager.LoadScene ("MainMenu");
	}

	// goes to countdown state
/*	public void softReset() {
		gameState = GameState.countdown;
		ScoreController.Instance.resetScore ();
		ScoreController.Instance.stop ();
		InputManager.Instance.disableInput ();
	}
*/
	// action is happening
	public void play(){
		Time.timeScale = TIME_SCALE;
		pauseMenu.SetActive (false);

		gameState = GameState.playing;
		ScoreController.Instance.resume ();
		InputManager.Instance.enableInput ();
	}

	// pause menu
	public void pause(){
		pauseMenu.SetActive (true);
		gameState = GameState.paused;
		Time.timeScale = 0.0f;
	}

	// level complete/ score gui
	public void complete(){
		gameState = GameState.complete;
		InputManager.Instance.disableInput ();
		GUIManager.Instance.activateFinish ();

		ScoreController.Instance.stop ();
		ScoreController.Instance.freeze ();
		ScoreController.Instance.submitScore ();

		// unlock gemblems
		GameObject.FindObjectOfType<GemblemCompletionUnlocker> ().maybeUnlock ();
		GameObject.FindObjectOfType<GemblemCollectorUnlocker>().maybeUnlock();
		GameObject.FindObjectOfType<GemblemTreasureUnlocker> ().maybeUnlock ();
		GameObject.FindObjectOfType<GemblemOverZeroUnlocker> ().maybeUnlock ();
		RankManager.Instance.storeRank ();
	}

}
