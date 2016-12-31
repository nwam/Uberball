using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUtils : MonoBehaviour {
	private const string SELECTED_CHARACTER = "character";
	public GameObject mainMenu;
	public GameObject levelSelect;
	public GameObject characterSelect;
	public GameObject options;
	public GameObject unlockPrompt;

	public void openLevelSelect() {
		mainMenu.SetActive (false);
		levelSelect.SetActive (true);
	}

	public void openMainMenu() {
		levelSelect.SetActive (false);
		options.SetActive (false);
		characterSelect.SetActive (false);
		mainMenu.SetActive (true);
	}

	public void openCharacterSelect() {
		mainMenu.SetActive (false);
		characterSelect.SetActive (true);
	}

	public void openOptions() {
		mainMenu.SetActive (false);
		options.SetActive (true);
		
	}

	public void startLevel(string levelName) {
		SceneManager.LoadScene (levelName);
	}

	public void selectCharacter(string materialName) {
		PlayerPrefs.SetString (SELECTED_CHARACTER, "ball/" + materialName);
		EventSystem.current.currentSelectedGameObject.transform.parent.parent.Find ("Hilighter").transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
	}

	public void displayUnlockPrompt(string name, string type, Texture image){
		unlockPrompt.transform.Find ("Name").GetComponent<Text> ().text = name;
		unlockPrompt.transform.Find ("Title").GetComponent<Text> ().text = "New " + type + " Unlocked!";
		unlockPrompt.transform.Find ("Image").GetComponent<RawImage> ().texture = image;
		unlockPrompt.SetActive (true);
	}

	public void hideUnlockPrompt(){
		unlockPrompt.SetActive (false);
	}

	public void resetProgress(){
		PlayerPrefs.DeleteAll ();
	}
		
}
