using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPrompt : Singleton<UnlockPrompt> {

	private string[] BUTTON_TEXTS = new string[]{
		"sounds about right",
		"i am excited",
		"the hype is real",
		"it's about time",
		"yay!",
		"\u0304\\_(\u30C4)_/\u0304",
		"i wasn't even trying",
		"i broke a sweat"
	};

	private struct UnlockPromptArgs
	{
		public string name;
		public string type;
		public string[] conditions;
		public Texture image;
	}

	private Queue<UnlockPromptArgs> unlockPromptQueue = new Queue<UnlockPromptArgs>();
	private bool displayLock = false;


	// display the prompt if it is not displaying anything
	// add to a queue otherwise
	public void maybeDisplay(string name, string type, string[] conditions, Texture image){
		UnlockPromptArgs upa = new UnlockPromptArgs {
			name = name,
			type = type,
			conditions = conditions,
			image = image
		};

		GetComponent<Animator> ().SetBool ("show", true);

		if (!displayLock) {
			display (upa);
		} else {
			unlockPromptQueue.Enqueue (upa);
		}
	}

	public void displayNext(){
		if (unlockPromptQueue.Count > 0) {
			display (unlockPromptQueue.Dequeue ());
		} else {
			hide ();
		}
	}



	private void display(UnlockPromptArgs args){
		if (displayLock) {
			GetComponent<Animator> ().SetTrigger ("reset");
		}
		displayLock = true;

		transform.Find ("Name").GetComponent<Text> ().text = args.name;
		transform.Find ("Title").GetComponent<Text> ().text = "New " + args.type + " Unlocked!";
		transform.Find ("Image").Find("Image").GetComponent<RawImage> ().texture = args.image;

		string conditionsString = "";
		foreach (string condition in args.conditions) {
			conditionsString = conditionsString + "        " + '\u2714' + " " + condition + '\n';
		}
		transform.Find ("Conditions").GetComponent<Text> ().text = conditionsString;

		Random.seed = (int)System.DateTime.Now.Ticks;
		string buttonText = BUTTON_TEXTS[Random.Range (0, BUTTON_TEXTS.Length - 1)];
		transform.Find ("Button").Find ("Text").GetComponent<Text> ().text = buttonText;
	}
		
	private void hide(){
		gameObject.SetActive (false);
	}
}
