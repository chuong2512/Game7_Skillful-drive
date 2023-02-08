using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CarExplosion : MonoBehaviour
    {
        //This script is attached to the car game object and it is used to detect the collision and trigger game over logic.
        [SerializeField]
        private GameObject explosionParticle = null;
        void OnCollisionEnter2D(Collision2D col)
        {
            PlayerPrefs.SetInt("NumberOfCrashes", PlayerPrefs.GetInt("NumberOfCrashes") + 1);
            explosionParticle.transform.parent = null;
            explosionParticle.SetActive(true);
            GameObject.Find("GameManager").GetComponent<Menus>().GameOver();
            GameObject.Find("ExplosionSound").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
