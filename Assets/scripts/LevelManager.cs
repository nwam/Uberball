using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Singleton<LevelManager> {

	public enum GameState { 
		intro,
		countdown,
		playing,
		paused,
		complete
	};

	private GameState gameState { get; set;}

	void Start() {
		gameState = GameState.countdown;//should be intro
	}

	// Update is called once per frame
	// TODO: Listen for pause (make a pause menu)
	void Update () {
		// reset game
		if (Input.GetKey ("5")) {
			hardReset ();		
		}
		if (Input.GetKey ("0")) {
			mainMenu ();
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
	public void softReset() {
		gameState = GameState.countdown;
		ScoreController.Instance.resetScore ();
		ScoreController.Instance.stop ();
		InputManager.Instance.disableInput ();
	}

	public void play(){
		gameState = GameState.playing;
		ScoreController.Instance.resume ();
		InputManager.Instance.enableInput ();
	}

	public void pause(){

	}


}
