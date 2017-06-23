using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextLerp : Lerper {
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	protected override void applyLerpval () {
		text.color = lerpval;
	}
}