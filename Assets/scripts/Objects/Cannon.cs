using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cannon : MonoBehaviour {

	public float power;
	public AudioClip fireSound;

	private CannonController cannonController;
	private RawImage cannonCrosshair;
	private Camera cannonCamera;
	private Camera mainCamera;
	private GameObject player;


	// Use this for initialization
	void Start () {
		cannonCrosshair = GameObject.Find ("Canvas/CannonCrosshair").GetComponent<RawImage> ();
		cannonController = gameObject.transform.parent.Find ("CannonCamera").GetComponent<CannonController> ();
		cannonCamera = gameObject.transform.parent.Find ("CannonCamera").GetComponent<Camera>();	
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}

	public void enterCannon(GameObject p) {
		//track the player that entered the cannon
		player = p;

		// change the camera
		cannonCamera.enabled = true;
		mainCamera.enabled = false;

		// enable the corsshair
		cannonCrosshair.enabled = true;

		// change the controls to control the cannonCamera
		cannonController.setAsActiveInputController();

		// animate the camera
		cannonCamera.GetComponent<LinearAnimation>().startAnimation();
	}

	public void fire(Vector3 cameraPosition, Vector3 direction) {
		// disable the crosshair
		cannonCrosshair.enabled = false;

		// change the camera back
		mainCamera.enabled = true;
		cannonCamera.enabled = false;

		// shoot the player like a cannon ball
		player.GetComponent<Transform>().position = cameraPosition;
		player.GetComponent<Rigidbody>().AddForce(direction * power);

		// return control to the ball
		player.GetComponent<PlayerController>().setAsActiveInputController();

		// play sound
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
}
