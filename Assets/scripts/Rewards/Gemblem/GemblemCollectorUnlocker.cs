/* Unlocked when player collects all points in a level */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemblemCollectorUnlocker : GemblemUnlocker {

	protected override void setMissionType(){
		missionType = MissionType.Collector;
	}

	protected override bool unlockCondition(){
		if (GameObject.FindGameObjectWithTag ("Points") == null) { // if all points all disabled
			return true;
		}
		return false;
	}
}
