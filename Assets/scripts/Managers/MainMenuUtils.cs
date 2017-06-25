using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuUtils : Singleton<MainMenuUtils> {
	public const string SELECTED_CHARACTER = "character";

	private Stack<GameObject> pageStack;

	public GameObject mainMenu;
	public GameObject stageSelect;
	public GameObject characterSelect;
	public GameObject options;

	private GameObject[] menuPages;

	void Start(){
		menuPages = new GameObject[] {
			mainMenu,
			stageSelect,
			characterSelect,
			options
		};
		pageStack = new Stack<GameObject> ();

		pushActivePage ();
	}

	// -- PAGE MANAGEMENT --

	private void pushActivePage(){
		foreach (GameObject menuPage in menuPages) {
			if (menuPage.activeInHierarchy) {
				pageStack.Push (menuPage);
				break;
			}
		}
	}

	private void closeAllPages(){
		foreach (GameObject menuPage in menuPages) {
			menuPage.SetActive (false);
		}
	}

	// -- NAVIGATION --

	public void openLevelSelect() {
		pushActivePage ();
		closeAllPages();
		stageSelect.SetActive (true);
	}

	public void openMainMenu() {
		pushActivePage ();
		closeAllPages();
		mainMenu.SetActive (true);
	}

	public void openCharacterSelect() {
		pushActivePage ();
		closeAllPages();
		characterSelect.SetActive (true);
	}

	public void openOptions() {
		pushActivePage ();
		closeAllPages();
		options.SetActive (true);
	}

	public void back(){
		closeAllPages ();
		if (pageStack.Count > 0) {
			pageStack.Pop ().SetActive (true);
		} else {
			mainMenu.SetActive (true);
		}
	}

	// -- MISC --

	public void startLevel(string levelName) {
		SceneManager.LoadScene (levelName);
	}

	public void selectCharacter(string characterName) {
		PlayerPrefs.SetString (SELECTED_CHARACTER, characterName);
		EventSystem.current.currentSelectedGameObject.transform.parent.parent.Find ("Hilighter").transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
	}

	public void resetProgress(){
		PlayerPrefs.DeleteAll ();
	}
		
}
