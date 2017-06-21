using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankDisplay : MonoBehaviour {

	public string level;

	void Start () {
		if (GemblemUnlocker.isUnlocked (level, GemblemUnlocker.MissionType.LevelComplete)) {
			RankManager.Rank levelRank = RankManager.getRank (level);
			print (levelRank.ToString ());
			transform.Find (levelRank.ToString ()).gameObject.SetActive (true);
		}
	}
}
