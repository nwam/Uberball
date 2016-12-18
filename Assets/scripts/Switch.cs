using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	private MeshRenderer upMesh;
	private MeshRenderer downMesh;
	private bool isActive;

	// Use this for initialization
	void Start () {
		upMesh = transform.Find ("switch_up").gameObject.GetComponent<MeshRenderer>();
		downMesh = transform.Find ("switch_down").gameObject.GetComponent<MeshRenderer>();
		isActive = false;
	}

	void Update () {
		if (isActive) {
			updateEffect ();
		}
	}

	// push the button down
	private void pushDown() {
		upMesh.gameObject.SetActive (false);
		downMesh.enabled = true;
	}

	public void activate() {
		pushDown ();
		isActive = true;
		effect ();
		gameObject.GetComponent<Collider> ().enabled = false;
	}

	// the effect of the switch
	protected virtual void effect() {
	}

	// an effect that requires update
	protected virtual void updateEffect(){
	}

}
