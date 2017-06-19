using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemblemTreasureUnlocker : GemblemUnlocker {

	protected override void setMissionType(){
		missionType = MissionType.HiddenTreasure;
	}

	protected override bool unlockCondition(){
		if (GameObject.FindGameObjectWithTag ("Treasure") == null) { // if the treasure was found
			return true;
		}
		return false;
	}
}
