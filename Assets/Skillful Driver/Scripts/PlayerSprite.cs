using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
	public class PlayerSprite : MonoBehaviour
	{

		//This script will change the sprite on the SpriteRenderer component to match the sprite of the item that player has chosen in the shop menu
		//This script is attached to the "Car" game obstacle
		public Sprite[] playerSprite;

		void Start()
		{
			LoadPlayerSprite();
		}

		public void LoadPlayerSprite()
		{
			if (PlayerPrefs.GetInt("ChoosenItem", 0) == 0)
			{
				SpriteRenderer sprite = GetComponent<SpriteRenderer>();
				sprite.sprite = playerSprite[0];
			}
			else
			{
				int choosenItem = (PlayerPrefs.GetInt("ChoosenItem", 0) - 1);
				SpriteRenderer sprite = GetComponent<SpriteRenderer>();
				sprite.sprite = playerSprite[choosenItem];
				Color color;
				ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("ItemColor" + (choosenItem + 1)), out color);
				sprite.color = color;
			}
		}
	}
}
