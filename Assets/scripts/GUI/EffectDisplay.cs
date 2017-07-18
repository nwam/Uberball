using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EffectDisplay : Singleton<EffectDisplay> {
	private Text effectTextDisplay;
	private List<string> effectList;

	// Use this for initialization
	void Start () {
		effectTextDisplay = GetComponent<Text> ();
		effectList = new List<string>();
	}

	void LateUpdate(){
		displayEffectText();
		effectList.Clear();
	}
		

	void displayEffectText(){
		// generate the text
		string effectText = "";
		foreach (string s in effectList){
			effectText += s + "\n";
		}

		// show the text on the screen
		effectTextDisplay.text = effectText;
	}

	public void addEffect (string status, int timeRemaining){
		effectList.Add (status + "|" + timeRemaining.ToString ());
	}
}
