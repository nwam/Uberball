using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	private const float DEFAULT_FORCE = 100;

	public GameObject player;

	private int timeRemain;
	private int magLevel;
	private EffectDisplay effectDisplay;
	private float force;
		
	void Start() {
		effectDisplay = GameObject.FindObjectOfType<EffectDisplay> ();
		timeRemain = 0;
		magLevel = 0;
		force = DEFAULT_FORCE;
	}

	void Update() {
		if (timeRemain > 0) {
			timeRemain--;

			// display the remaining magnet time in effecDisplay
//			effectDisplay.addEffect ("mag" + magLevel.ToString () + " ", timeRemain);

			// disable magnet when time runs out
			if (timeRemain <= 0) {
				setRadius (0);
				magLevel = 0;
			}
		}

	}

	// function to run effect
	public void magnetize(int radius, int magTime, int lvl){
		force = DEFAULT_FORCE;
		setRadius (radius);
		timeRemain = magTime;
		magLevel = lvl;
	}

	// enables magnet without time or printing information
	public void magnetize(float radius, float pullForce){
		timeRemain = 0;
		setRadius (radius);
		force = pullForce;
		
	}

	public void demagnetize(){
		setRadius (0);
		force = DEFAULT_FORCE;
	}

	void FixedUpdate(){
		transform.position = player.transform.position; 
	}

	public float getForce() {
		return force;
	}

	private void setRadius(float r){
		transform.localScale = new Vector3 (r, r, r);
	}



}
