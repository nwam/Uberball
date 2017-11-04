using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemblemOverZeroUnlocker : GemblemUnlocker {

	protected override void setMissionType(){
		missionType = MissionType.OverZeroPoints;
	}

	protected override bool unlockCondition(){
		return HighscoreManager.Instance.getHighscore (1) >= 0;
	}
}
