using UnityEngine;
using System.Collections;

public class HueRotator	 : MonoBehaviour {
	public float duration = 8.0f;
	public Renderer rend;
	float hue;

	void Start () {
		rend = GetComponent<Renderer> ();
	}
	// Update is called once per frame
	void Update () {
		hue = Time.time/duration % 1;
		rend.material.color = Color.HSVToRGB(hue, 1, 1);
	}
}
