using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float xspeed = 0;
	public float yspeed = 120;
	public float zspeed = 0;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (xspeed, yspeed, zspeed) * Time.deltaTime);
	}
}
