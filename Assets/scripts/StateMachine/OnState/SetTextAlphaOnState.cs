using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextAlphaOnState : OnAnimatorState {

	public Text text;
	public float v;

	protected override void actionOnState(){
		text.color = new Color (text.color.r, text.color.g, text.color.b, v);
	}
}
