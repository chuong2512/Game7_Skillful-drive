using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringWheel : MonoBehaviour {

	public GameObject steeringWheel;
	public SteeringWheelRotateBack backToZeroDegreeRotation;

	private float zRot;
	public float maxAngle = 360;
	public float returnValue = 180;
	public bool spinBackToCenter = true;
	[Range(100, 1000)]
	public int spinBackToCenterPositionSpeed = 500;
	private float angle;
	public static float axis;
	[HideInInspector]
	public float rotation = 0;

	public void OnPointerDown(BaseEventData data) {
		PointerEventData pointerData = data as PointerEventData;

		backToZeroDegreeRotation.enabled = false;
		angle = Mathf.Atan2(steeringWheel.transform.position.x - pointerData.position.x, steeringWheel.transform.position.y - pointerData.position.y);
		zRot = steeringWheel.transform.eulerAngles.z - (Mathf.Rad2Deg * -angle);
		steeringWheel.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * -angle + zRot, Vector3.forward);
	}

	public void OnPointerUp(BaseEventData data)
	{
		axis = 0;
		if (spinBackToCenter)
		{
			backToZeroDegreeRotation.enabled = true;
		}
	}
	public void OnDragEnd() {
		axis = 0;
		if(spinBackToCenter) {
			backToZeroDegreeRotation.enabled = true;
		}
	}

	public void RotateWheel(BaseEventData data) {
		PointerEventData pointerData = data as PointerEventData;

		float previousRotation = steeringWheel.transform.eulerAngles.z;
		angle = Mathf.Atan2(steeringWheel.transform.position.x - pointerData.position.x, steeringWheel.transform.position.y - pointerData.position.y);
		rotation += Mathf.DeltaAngle(Mathf.Rad2Deg * -angle + zRot, previousRotation);

		if(rotation < maxAngle && rotation > -maxAngle) {
			steeringWheel.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * -angle + zRot, Vector3.forward);
		}else if(rotation > maxAngle){
			rotation = maxAngle;
			steeringWheel.transform.rotation = Quaternion.AngleAxis(-maxAngle, Vector3.forward);
		}else if(rotation < -maxAngle) {
			rotation = -maxAngle;
			steeringWheel.transform.rotation = Quaternion.AngleAxis(maxAngle, Vector3.forward);
		}

		zRot = steeringWheel.transform.eulerAngles.z - (Mathf.Rad2Deg * -angle);
		axis = returnValue / maxAngle * rotation;
	}

	public void ResetAll()
    {
		zRot = 0;
		axis = 0;
		rotation = 0;
		steeringWheel.transform.rotation = Quaternion.Euler(0, 0, 0);

	}
}
