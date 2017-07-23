using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
	
	public float maxXRotSpeed = 90.0f;
	public float maxYRotSpeed = 90.0f;
	public float maxZRotSpeed = 90.0f;

	public float deltaXRotSpeed = 15.0f;
	public float deltaYRotSpeed = 15.0f;
	public float deltaZRotSpeed = 15.0f;

	private float xRotSpeed;
	private float yRotSpeed;
	private float zRotSpeed;

	private float xRot;
	private float yRot;
	private float zRot;

	// Use this for initialization
	void Start () {
		Random.InitState (580108);
		xRot = 0;
		yRot = 0;
		zRot = 0;

		xRotSpeed = 0;
		yRotSpeed = 0;
		zRotSpeed = 0;

		// convert to per-update
		deltaXRotSpeed *= Time.fixedDeltaTime;
		deltaYRotSpeed *= Time.fixedDeltaTime;
		deltaZRotSpeed *= Time.fixedDeltaTime;
		maxXRotSpeed *= Time.fixedDeltaTime;
		maxYRotSpeed *= Time.fixedDeltaTime;
		maxZRotSpeed *= Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// update rotation speeds
		xRotSpeed += signedRandom()*deltaXRotSpeed;
		yRotSpeed += signedRandom()*deltaYRotSpeed;
		zRotSpeed += signedRandom()*deltaZRotSpeed;

		xRotSpeed = Mathf.Min (xRotSpeed, maxXRotSpeed);
		yRotSpeed = Mathf.Min (yRotSpeed, maxYRotSpeed);
		zRotSpeed = Mathf.Min (zRotSpeed, maxZRotSpeed);

		xRotSpeed = Mathf.Max (xRotSpeed, -maxXRotSpeed);
		yRotSpeed = Mathf.Max (yRotSpeed, -maxYRotSpeed);
		zRotSpeed = Mathf.Max (zRotSpeed, -maxZRotSpeed);

		// apply rotation speeds
		xRot += xRotSpeed;
		yRot += yRotSpeed;
		zRot += zRotSpeed;

		transform.rotation = Quaternion.Euler (new Vector3 (xRot, yRot, zRot));
	}


	// returns random value between -1 and 1
	private float signedRandom(){
		return (Random.value - 0.5f) * 2;

	}
}
