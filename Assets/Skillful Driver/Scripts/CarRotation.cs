using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CarRotation : MonoBehaviour
    {
        //This script is used to rotate the car game object when player turns the steering wheel
        private float rot = 0;

        void Update()
        {
            rot -= SteeringWheel.axis * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, rot + transform.rotation.z * Mathf.Rad2Deg), 200 * Time.deltaTime);
        }
    }
}
