using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class EnableDiamondsOnTheGameArea : MonoBehaviour
    {
        //It is attached to the "Diamonds" game object in each game area. And it is used to randomly spawn 3 out of 10 diamonds in the area
        public GameObject[] diamonds;

        void Start()
        {
            int numberOfEnabledDiamonds = 5;
            while (numberOfEnabledDiamonds > 0)
            {
                int enableRandomDiamond = Random.Range(1, diamonds.Length);
                if (!diamonds[enableRandomDiamond].activeSelf)
                {
                    diamonds[enableRandomDiamond].SetActive(true);
                    numberOfEnabledDiamonds--;
                }
            }
        }

    }
}
