using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureUnstretcher : MonoBehaviour {

	void Start()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector2[] uvs = mesh.uv;

		for(int i  = 0; i < uvs.Length; i++)
		{
			// shift texture
			float shift =  transform.localScale.x - ((float)((int)transform.localScale.x));
			uvs [i] = new Vector2 (uvs [i] [0] + shift, uvs [i] [1]);

			// remove scaling issues
			uvs[i].Scale(new Vector2(transform.localScale.x, transform.localScale.y));
		}

		mesh.uv = uvs;
	}

}
