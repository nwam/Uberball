using UnityEngine;
using System.Collections;

public class TransformSwitch : Switch {

	public Transform targetObject;
	public Vector3 targetPosition;
	public Vector3 targetRotation;
	public Vector3 targetScale;

	public float positionSpeed;
	public float rotationSpeed;
	public float scaleSpeed;

	protected override void updateEffect() {
		targetObject.position = Vector3.MoveTowards (targetObject.position, targetPosition, positionSpeed/60.0f);
		targetObject.eulerAngles = Vector3.MoveTowards (targetObject.eulerAngles, targetRotation, rotationSpeed/60.0f);
		targetObject.localScale = Vector3.MoveTowards (targetObject.localScale, targetScale, scaleSpeed/60.0f);
	}
}
