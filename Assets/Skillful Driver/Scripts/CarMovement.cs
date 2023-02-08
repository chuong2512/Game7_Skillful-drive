using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SkillfulDriver
{
    public class CarMovement : MonoBehaviour
    {
        //This script is attached to the car game object and it is used to move the car in the direction its facing
        [SerializeField]
        private Rigidbody2D rb;
        private Text score;
        private float speed = 5;

        void Start()
        {
            score = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        void Update()
        {
            transform.position += transform.up * Time.deltaTime * speed;
            Vars.score += Time.deltaTime;
            score.text = "SCORE: " + (int)Vars.score;
            speed += Time.deltaTime / 100;

        }
    }
}
