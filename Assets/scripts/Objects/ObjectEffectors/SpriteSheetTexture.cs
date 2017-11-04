using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetTexture : MonoBehaviour {

	public float speed=1;
	public int count;
	public int count_x;
	public int count_y;

	private float start_x;
	private float start_y;

	private int current_x;
	private int current_y;

	private int counter;
	private int fixedCounter;

	private Material mat;

	void Start(){
		mat = GetComponent<Renderer> ().material;
		mat.mainTextureScale = new Vector2 (1/(float)count_x, 1/(float)count_y);
		start_x = mat.mainTextureOffset [0];
		start_y = mat.mainTextureOffset [1];

		fixedCounter = 0;
	}

	void FixedUpdate(){
		fixedCounter = fixedCounter + 1;
		counter = (int)(fixedCounter*speed) % count;

		mat.mainTextureOffset = new Vector2 (start_x + (float)(counter % 8) / count_x, start_y - (float)(counter / 8) / count_y);
	}

}
