using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorBoolOnState : MonoBehaviour {

	public Animator animator;
	public string boolParameterName;
	public bool value;
	public string onState;

	// Update is called once per frame
	void Update () {
		if(animator != null && inState(gameObject.GetComponent<Animator>(), onState)){
			animator.SetBool (boolParameterName, value);
		}
	}

	private static bool inState(Animator animator, string state){
		return animator.GetCurrentAnimatorStateInfo (0).IsName (state);
	}
}
