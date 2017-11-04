using UnityEngine;
using System.Collections;

public class Lerper : MonoBehaviour {
	public Color color0;
	public Color color1;
	protected Color lerpval; 
	public float speed;

	protected virtual void applyLerpval() {
	}

	// Update is called once per frame
	void Update () {	
		lerpval = Color.Lerp (color0, color1, Mathf.PingPong(Time.time * speed, 1));

		// apply the color to emission color
		applyLerpval();
	}
}
