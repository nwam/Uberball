using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankDisplay : MonoBehaviour {

	public string level;

	void Start () {
		if (RankManager.hasRank(level)) {
			RankManager.Rank levelRank = RankManager.getRank (level);
			transform.Find (levelRank.ToString ()).gameObject.SetActive (true);
		}
	}
}
