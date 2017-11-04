using UnityEngine;
using System.Collections;

public class EmissionLerp : Lerper {
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	protected override void applyLerpval(){
		rend.material.SetColor ("_EmissionColor", lerpval);
	}
}
