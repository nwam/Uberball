using UnityEngine;
using System.Collections;

public class ShapeGate : Gate {

	public GameObject shape;
	public bool crazyShape;
	private GameObject ogPlayer;
	private ThirdPersonOrbitCam cam;
	private SphereCollider playerOgCollider;
	private MeshCollider playerNewCollider;
	private Mesh ogMesh;
	private InputManager inputManager;

	protected override void effect(GameObject obj) {
		if (!crazyShape) {
			MeshFilter meshFilter = obj.GetComponent<MeshFilter> ();
			Mesh newMesh = shape.GetComponent<MeshFilter> ().mesh;

			// get the colliders
			playerOgCollider = obj.GetComponent<SphereCollider> ();
			playerNewCollider = obj.GetComponent<MeshCollider> ();

			//set up and enable the new collider
			playerNewCollider.sharedMesh = newMesh;
			playerNewCollider.enabled = true;

			// disable the sphere collider
			playerOgCollider.enabled = false;

			// save the original mesh
			ogMesh = meshFilter.mesh;

			// apply the new mesh
			meshFilter.mesh = newMesh;
		} else {

			cam = GameObject.FindObjectOfType<ThirdPersonOrbitCam> ();
			inputManager = GameObject.FindObjectOfType<InputManager> ();

			// store the player object
			ogPlayer = obj;

			// disable the player's attributes


			// set shape's transform to player's transform
			shape.transform.position = ogPlayer.transform.position;
			shape.transform.rotation = ogPlayer.transform.rotation;
			cam.player = shape.transform;

			// enable the new shape
			ogPlayer.SetActive (false);
			shape.SetActive (true);

			inputManager.setActiveController (shape.GetComponent<PlayerController> ());
		}
	}

	public override void disableEffect(GameObject obj) {
		if (!crazyShape) {
			// apply the original mesh
			MeshFilter meshFilter = obj.GetComponent<MeshFilter> ();
			meshFilter.mesh = ogMesh; 

			// enable the sphere collider
			playerOgCollider.enabled = true;

			// disable the mesh collider
			playerNewCollider.enabled = false;
		} else {
			cam.player = ogPlayer.transform;
			ogPlayer.transform.position = shape.transform.position;
			shape.SetActive (false);
			ogPlayer.SetActive (true);
			inputManager.setActiveController (ogPlayer.GetComponent<PlayerController> ());

		}
	}

	protected override void setType(){
		type = EffectDisplay.EffectType.shape;
	}
}
