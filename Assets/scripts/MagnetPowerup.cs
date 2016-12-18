using UnityEngine;
using System.Collections;

public class MagnetPowerup : Powerup {
	private const int MAG_TIME = 400;
	private Magnet magnet;

	protected override void setType(){
		type = "magnet";
	}

	protected override void afterStart(){
		magnet = GameObject.FindObjectOfType<Magnet>().GetComponent<Magnet>();
	}
		
	public override void effect(int powerLevel) {
		magnet.magnetize ((int)Mathf.Pow (2, powerLevel), MAG_TIME, powerLevel);
	}

}
