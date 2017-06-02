using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	enum State { 
		intro,
		countdown,
		playing,
		paused,
		highscores
	};

	private State gameState { get; set; }



	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
