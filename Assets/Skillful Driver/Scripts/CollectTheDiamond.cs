using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CollectTheDiamond : MonoBehaviour
    {
        //This script is attached to the diamonds that will spawn on each game area. And it is used to trigger the logic when player collect it
        [SerializeField]
        private GameObject explosionParticle = null;
        void OnTriggerEnter2D(Collider2D col)
        {
            if (PlayerPrefs.GetInt("Vibration") == 1)
            {
                Handheld.Vibrate();
            }
            GameObject.Find("DiamondCollectSound").GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("TotalNumberOfDiamonds", PlayerPrefs.GetInt("TotalNumberOfDiamonds") + 1);
            PlayerPrefs.SetInt("NumberOfDiamonds", PlayerPrefs.GetInt("NumberOfDiamonds") + 1);
            explosionParticle.SetActive(true);
            explosionParticle.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
