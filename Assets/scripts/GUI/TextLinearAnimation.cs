using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLinearAnimation : MonoBehaviour {

	public Vector3 midPosition;
	public Vector3 endPosition;

	public int midAlpha;
	public int endAlpha;

	public int startAnimationTime;
	public int waitTime;
	public int endAnimationTime;

	private bool animate;

	void Start () {
		animate = false;

	}

	public void begin(){
		animate = true;
	}

	// Update is called once per frame
	void Update () {
		if (animate) {

		}
	}
}
