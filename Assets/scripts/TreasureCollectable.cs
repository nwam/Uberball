using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollectable : MonoBehaviour {

	public void getCollected(){
		if (LevelManager.Instance.gameState == LevelManager.GameState.playing) {
			gameObject.SetActive (false);
		}
	}
}
