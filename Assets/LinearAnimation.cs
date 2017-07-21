using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAnimation : MonoBehaviour {

	public Vector3 sourcePosition;
	private Vector3 targetPosition;

	public float animationSpeed;

	private bool animate;

	void Start(){
		animate = false;
		targetPosition = transform.position;
		transform.localPosition = sourcePosition;
	}

	void FixedUpdate(){
		if (animate) {
			move ();
		}
	}

	private void move() {
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, animationSpeed/50.0f);
	}

	public void startAnimation(){
		animate = true;
	}
}
