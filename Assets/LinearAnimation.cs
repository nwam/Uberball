using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAnimation : MonoBehaviour {

	public Vector3 sourcePosition;
	private Vector3 targetPosition;

	private Quaternion sourceRotation;

	public float animationSpeed;

	private bool animate;

	void Start(){
		animate = false;
		targetPosition = transform.position;
		transform.localPosition = sourcePosition;
		sourceRotation = transform.rotation;
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
		GetComponent<AudioSource> ().Play ();
	}

	public void reset(){
		animate = false;
		transform.localPosition = sourcePosition;
		transform.rotation = sourceRotation;
	}
}
