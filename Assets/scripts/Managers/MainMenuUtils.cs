﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenuUtils : Singleton<MainMenuUtils> {
	public const string SELECTED_CHARACTER = "character";

	public GameObject mainMenu;
	public GameObject levelSelect;
	public GameObject characterSelect;
	public GameObject options;

	// -- NAVIGATION --

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