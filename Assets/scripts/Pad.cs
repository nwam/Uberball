using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {

	protected Vector3 direction;
	public float power;

	void Start() {
		setDirection ();
	}

	public virtual void setDirection(){
	}

	public Vector3 getDirection() {
		return direction;
	}

	public float getPower(){
		return power;
	}
}
