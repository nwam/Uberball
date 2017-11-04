using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableAward : MonoBehaviour {

	public string level; 
	public GemblemUnlocker.MissionType missionType; 


	void Start () {
		if (GemblemUnlocker.isUnlocked(level, missionType)){
			gameObject.SetActive(true);
		} else {
			gameObject.SetActive(false);
		}
	}
}
