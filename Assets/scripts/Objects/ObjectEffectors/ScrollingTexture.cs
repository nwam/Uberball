using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour {

	public float speedU;
	public float speedV;

	void FixedUpdate(){
		float offsetU = Time.time * speedU;
		float offsetV = Time.time * speedV;

		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (offsetU, -offsetV);
	}
}