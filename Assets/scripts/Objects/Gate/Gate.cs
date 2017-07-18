using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public int effectTime;

	protected EffectDisplay.EffectType type;
	private bool effectActive;
	private int timeRemaining; 

	private GameObject player;

	protected virtual void effect(GameObject obj) {
	}

	public void enableEffect(GameObject obj){
		timeRemaining = effectTime; 
		if (!effectActive) {
			player = obj;
			effect (obj);
		}
		effectActive = true;

	}

	public virtual void disableEffect(GameObject obj){
	}

	protected virtual void Start() {
		effectActive = false;
		setType ();

		// link every gate to the StatusDisplay

	}

	void Update(){
		// if the effect is active
		if (effectActive) {
			// add the effect to the effectDisplay
			EffectDisplay.Instance.addEffect (type, timeRemaining);
		}
	}

	void FixedUpdate() {
		// if the effect is active
		if (effectActive) {

			if (LevelManager.Instance.gameState != LevelManager.GameState.paused) {
				// decrease the remaining time
				timeRemaining--;

				// if the time is up
				if (timeRemaining < 0) {

					// reset the effect timer and disable the effect
					effectActive = false;
					timeRemaining = effectTime;
					disableEffect (player);

					// play the disable sound
					GetComponents<AudioSource>()[1].Play();
				}
			}
		}
	}

	protected virtual void setType(){
	}

	public void killGUI(){
		effectActive = false;
	}

	public bool isActive(){
		return effectActive;
	} 

}
