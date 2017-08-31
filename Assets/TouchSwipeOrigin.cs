using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchSwipeOrigin : MonoBehaviour {

	Vector2 touchOrigin;
	RectTransform rect;

	void Start(){
		rect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			setPositionToTouchOrigin ();
		} else {
			hide ();
		}
	}

	private void setPositionToTouchOrigin(){

		Touch touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began){
			touchOrigin = touch.position;
		}

		rect.anchoredPosition = new Vector3 (touchOrigin.x - rect.localScale.x/2, touchOrigin.y - rect.localScale.y/2, 0);
	}

	private void hide(){
		rect.anchoredPosition = Vector3.one * -100;
	}
}
