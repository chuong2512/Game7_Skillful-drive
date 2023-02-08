using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelRotateBack : MonoBehaviour {

	public SteeringWheel steeringWheel;

	void Update () {
		if(steeringWheel.rotation < 0)	{
			steeringWheel.rotation += steeringWheel.spinBackToCenterPositionSpeed * Time.deltaTime;
			transform.rotation = Quaternion.AngleAxis(-steeringWheel.rotation, Vector3.forward);
		}
			
		if(steeringWheel.rotation > 0)	{
			steeringWheel.rotation -= steeringWheel.spinBackToCenterPositionSpeed * Time.deltaTime;
			transform.rotation = Quaternion.AngleAxis(-steeringWheel.rotation, Vector3.forward);
		}	

		if(steeringWheel.rotation < steeringWheel.spinBackToCenterPositionSpeed * Time.deltaTime && steeringWheel.rotation > -steeringWheel.spinBackToCenterPositionSpeed * Time.deltaTime) {
			steeringWheel.rotation = 0;
			transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
			this.enabled = false;
		}
		
		//SteeringWheel.axis = steeringWheel.returnValue / steeringWheel.maxAngle * steeringWheel.rotation;
	}
}
