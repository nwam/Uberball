using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimatorState : MonoBehaviour {

	public string stateName;

	void Update () {
		if(gameObject.GetComponent<Animator> () != null && inState(stateName)){
			actionOnState ();
		}
	}

	private bool inState(string state){
		return gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName (state);
	}

	protected static bool inState(Animator anim, string state){
		return anim.GetCurrentAnimatorStateInfo (0).IsName (state);
	}

	protected virtual void actionOnState(){

	}
}
