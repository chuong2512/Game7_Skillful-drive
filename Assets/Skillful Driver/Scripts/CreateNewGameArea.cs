using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class CreateNewGameArea : MonoBehaviour
    {
        //It will create a new game area at the start of the game and each time player passes middle point of a previous game area
        public void NewGameArea(float parentGameObjectYPos)
        {
            Vars.gameAreaObjectsCount++;
            int randomShape = Random.Range(1, 11);//There are 10 game areas in the folder "Resources", so this is used to randomly spawn one of it on scene
            GameObject gameArea = Instantiate(Resources.Load("GameArea" + randomShape) as GameObject);
            gameArea.transform.position = new Vector2(0, parentGameObjectYPos + 25.66f);
            gameArea.transform.parent = GameObject.Find("GameArenaObjects").transform;
            gameArea.gameObject.name = "GameArea" + Vars.gameAreaObjectsCount;
            if (Vars.gameAreaObjectsCount == 2) return;
            Destroy(GameObject.Find("GameArea" + (Vars.gameAreaObjectsCount - 2)));
        }

    }
}
