using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Debug : MonoBehaviour {

	private Rigidbody rb;
	private Text t;

	public int refreshRate;
	private int refreshClock;
	private float maxXZ;
	private float maxY;

	// Use this for initialization
	void Start () {
		rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody>();
		t = GetComponent<Text> ();
		refreshClock = 0;
		maxXZ = 0;
		maxY = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = rb.velocity;
		float xy = Mathf.Sqrt (Mathf.Pow (v.x, 2) + Mathf.Pow (v.z, 2));

		if (refreshClock++ > refreshRate) {
			refreshClock = 0;
			maxXZ = 0;
			maxY = 0;
		}

		maxXZ = Mathf.Max(maxXZ, xy);
		maxY = Mathf.Max (maxY, v.y);

		t.text = string.Format ("xz:{0,3:N1} y:{1,3:N1}\nxz:{2,3:N1} y:{3,3:N1}", 
			xy, 
			v.y,
			maxXZ,
			maxY
			);
	}
}
