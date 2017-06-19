using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollectable : MonoBehaviour {

	public void getCollected(){
		gameObject.SetActive (false);
	}
}
