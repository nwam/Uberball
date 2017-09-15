using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalUnlocker : Unlocker {
	void Start() {
		key = SceneManager.GetActiveScene ().name + "_complete";
	}
}
