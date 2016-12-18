using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerupManager : MonoBehaviour {
	public Powerup powerup;
	public int powerLevel;
	private Text powerupDisplay;

	// Use this for initialization
	void Start () {
		powerLevel = 0;
		powerup = null;
		powerupDisplay = GameObject.Find ("Canvas/PowerupDisplay").GetComponent<Text> ();
		powerupDisplay.text = "";
	}
	
	public void collect(Powerup collected){
		if (powerup == null || collected.getType () == powerup.getType ()) {
			// collected powerup matches current powerup build
			powerLevel++;

		} else {
			// collect powerup does not match current powerup build
			powerLevel = 1;
		}
		powerup = collected;
		powerupDisplay.text = powerup.getType () + " " + powerLevel;
	}

	public void use(){
		powerup.effect (powerLevel);
		powerLevel = 0;
		powerup = null;
		powerupDisplay.text = "";
	}
}
