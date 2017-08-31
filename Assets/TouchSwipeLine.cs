using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSwipeLine : MonoBehaviour {
	Vector2 touchOrigin;
	LineRenderer line;


	void Start(){
		line = GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			setLineEndpoints ();
		} else {
			hideLine ();
		}

	}

	private void setLineEndpoints(){

		Touch touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began){
			touchOrigin = touch.position;
		}

		Vector2 touchHead = touch.position;

		line.SetPosition (0, new Vector3(touchOrigin.x, touchOrigin.y, 0));
		line.SetPosition (1, new Vector3 (touchHead.x, touchHead.y, 0));

	}

	private void hideLine(){
		line.SetPosition (0, -Vector3.one);
		line.SetPosition (1, -Vector3.one);
	}

}
