using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {

	protected Vector3 direction;
	public float power;

	void Start() {
		setDirection ();
	}

	protected virtual void setDirection(){
	}

	public virtual void effect(GameObject player){
	}
}
