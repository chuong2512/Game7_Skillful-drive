using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class RoadColor : MonoBehaviour
    {
        //This script is used to change the color of the road
        void Start()
        {
            ChangeTheRoadColor();
        }

        public void ChangeTheRoadColor()
        {
            GetComponent<UnityEngine.U2D.SpriteShapeRenderer>().color = Vars.roadColor;
        }

    }
}
