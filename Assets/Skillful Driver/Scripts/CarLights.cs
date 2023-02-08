using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CarLights : MonoBehaviour
    {
        //This script is attached on each of the cars headlight and it is used for creating a simple light flashing animation
        private SpriteRenderer carLight;
        private float alpha = 1;
        private bool up = false;
        void Start()
        {
            carLight = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if (up)
            {
                alpha += Time.deltaTime / 2;
                if (alpha >= 1)
                {
                    up = false;
                }
            }
            else
            {
                alpha -= Time.deltaTime / 2;
                if (alpha <= 0.5f)
                {
                    up = true;
                }
            }
            carLight.color = new Color(1, 1, 1, alpha);
        }
    }
}
