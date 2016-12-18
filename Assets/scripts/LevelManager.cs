using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// reset game
		if (Input.GetKey ("5")) {
			resetLevel ();		
		}
		if (Input.GetKey ("0")) {
			mainMenu ();
		}
	}

	// Resets the current level
	public void resetLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// goes to main menu
	void mainMenu() {
		SceneManager.LoadScene ("MainMenu");
	}
}
