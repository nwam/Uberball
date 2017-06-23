using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	protected string type;
	private PowerupManager powerupManager;
	protected GameObject collectedBy;

	// Use this for initialization
	void Start () {
		powerupManager = GameObject.FindObjectOfType<PowerupManager> ();
		setType ();
		afterStart ();
	}
		
	public void getCollected(GameObject obj){
		collectedBy = obj;
		powerupManager.collect (this);
		gameObject.SetActive (false);
	}

	public virtual void effect(int powerLevel){
	}

	protected virtual void setType(){
	}

	public string getType(){
		return type;
	}

	protected virtual void afterStart(){
	}

}
