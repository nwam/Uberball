using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemblemCompletionUnlocker : GemblemUnlocker {

	protected override void setMissionType(){
		missionType = MissionType.LevelComplete;
	}

	protected override bool unlockCondition(){
		return true;
	}
}
