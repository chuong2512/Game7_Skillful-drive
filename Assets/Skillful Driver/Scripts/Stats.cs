using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SkillfulDriver
{
    public class Stats : MonoBehaviour
    {
        //This script will load the stats each time player enters the stats menu
        [SerializeField]
        private Text lastScore = null;
        [SerializeField]
        private Text bestScore = null;
        [SerializeField]
        private Text itemsOwned = null;
        [SerializeField]
        private Text diamondsCollected = null;
        [SerializeField]
        private Text numberOfCrashes = null;
        [SerializeField]
        private Text gamesPlayed = null;

        void OnEnable()
        {
            lastScore.text = "LAST SCORE: " + PlayerPrefs.GetInt("LastScore");
            bestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
            itemsOwned.text = "ITEMS OWNED: " + (PlayerPrefs.GetInt("ItemsOwned", 0) + 1) + "/9";
            diamondsCollected.text = "DIAMONDS COLLECTED: " + PlayerPrefs.GetInt("TotalNumberOfDiamonds");
            numberOfCrashes.text = "NUMBER OF CRASHES: " + PlayerPrefs.GetInt("NumberOfCrashes");
            gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefs.GetInt("GamesPlayed");
        }
    }
}
