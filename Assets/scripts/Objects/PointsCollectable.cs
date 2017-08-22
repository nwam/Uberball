using UnityEngine;
using System.Collections;

public class PointsCollectable : MonoBehaviour {

	private ScoreController scoreController;
	public int amount;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.FindObjectOfType<ScoreController> ();
		rb = GetComponent<Rigidbody> ();

	}

	public void getCollected() {
		if (LevelManager.Instance.gameState == LevelManager.GameState.playing ||
			LevelManager.Instance.gameState == LevelManager.GameState.countdown) {
			gameObject.SetActive (false);
			scoreController.addScore (amount);
		}
	}

	// for magnet
	void OnTriggerStay(Collider col) {
		GameObject obj = col.gameObject;

		if (obj.CompareTag("Magnet")){
			Magnet magnet = obj.GetComponent<Magnet> ();
			Vector3 directionToMagnet = (obj.transform.position - transform.position).normalized;
			rb.AddForce (directionToMagnet * magnet.getForce ());
		}
	}

}
