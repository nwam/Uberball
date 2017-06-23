using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemblemCounter: MonoBehaviour {

	private string[] levels = new string[2] {
		"TheTree",
		"BBCliff"
	};

	private int startGemblems;
	private int gemblemDisplay;

	// Use this for initialization
	void Start () {
		startGemblems = countTotalGemblems ();
		gemblemDisplay = startGemblems;
		setText (gemblemDisplay);
	}

	private int countTotalGemblems(){
		int gemblemCount = 0;
		foreach (string level in levels){
			gemblemCount = gemblemCount + GemblemUnlocker.countUnlockedGemblems (level);
		}
		return gemblemCount;
	}

	public int getStartGemblems(){
		return startGemblems;
	}

	public void incrementDisplay(){
		setText (++gemblemDisplay);
	}
		
	private void setText(int n){
		GetComponent<Text> ().text = "x" + n.ToString();
	}
}
