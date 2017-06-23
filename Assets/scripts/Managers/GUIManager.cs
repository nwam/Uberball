using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager> {

	public GameObject finish;
	public GameObject countdown;

	public Animator highscoresTable;

	public void activateContdown(){
		countdown.SetActive (true);
	}

	public void activateFinish(){
		finish.SetActive (true);
	}
	
}
