using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SkillfulDriver
{
    public class MenuTransitionAnimation : MonoBehaviour
    {
        //This script is used to create a fade in - fade out animation on the CanvasGroup component that is attached to the Canvas game object
        [SerializeField]
        private CanvasGroup cg = null;
        private float alpha = 1;
        public bool shouldFadeIn = true;

        void OnEnable()
        {
            GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;
            if (shouldFadeIn)
            {
                alpha = 0;
            }
            else
            {
                alpha = 1;

            }
        }

        void Update()
        {
            if (shouldFadeIn)
            {
                alpha += Time.deltaTime * 3;
                cg.alpha = alpha;
                if (alpha >= 1)
                {
                    cg.alpha = 1;
                    GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
                    GetComponent<MenuTransitionAnimation>().enabled = false;
                }
            }
            else
            {
                alpha -= Time.deltaTime * 3;
                cg.alpha = alpha;
                if (alpha <= 0)
                {
                    cg.alpha = 1;
                    GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
                    this.gameObject.SetActive(false);
                    GetComponent<MenuTransitionAnimation>().enabled = false;
                }
            }


        }
    }
}
