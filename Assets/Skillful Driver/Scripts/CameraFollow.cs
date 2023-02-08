using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CameraFollow : MonoBehaviour
    {
        //This script is attached to the camera and it is used to follow the car game object
        public GameObject car;
        void LateUpdate()
        {
            if (car == null) return;
            transform.position = new Vector3(car.transform.position.x, car.transform.position.y, -10);
        }
    }
}
