using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageColorLerp : Lerper {

	protected override void applyLerpval ()
	{
		GetComponent<Image> ().color = lerpval;
	}
}
