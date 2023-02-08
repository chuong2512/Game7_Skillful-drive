using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class AreaMiddlePoint : MonoBehaviour
    {
        //This script is attached to the game object that is placed in the middle of each game area.
        //It will detect when a user enters the collider that is set as trigger, and it will create a new game area and delete the old one.
        void OnTriggerEnter2D(Collider2D col)
        {
            GameObject.Find("GameManager").GetComponent<CreateNewGameArea>().NewGameArea(transform.parent.gameObject.transform.position.y);
            Destroy(this.gameObject);
        }
    }
}