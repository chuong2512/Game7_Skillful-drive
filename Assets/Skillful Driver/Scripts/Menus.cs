using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SkillfulDriver
{
    public class Menus : MonoBehaviour
    {
        //This script is attached to the "GameManager" game object and it is used for navigation through the different menus
        [SerializeField]
        private CarMovement carMovement = null;
        [SerializeField]
        private CarRotation carRotation = null;
        [SerializeField]
        private GameObject mainMenu = null;
        [SerializeField]
        private Text numberOfDiamonds = null;
        [SerializeField]
        private GameObject statsMenu = null;
        [SerializeField]
        private GameObject shopMenu = null;
        [SerializeField]
        private GameObject giftMenu = null;
        [SerializeField]
        private GameObject giftMenuDiamondImage = null;
        [SerializeField]
        private GameObject settingsMenu = null;
        [SerializeField]
        private GameObject gameplayMenu = null;
        [SerializeField]
        private GameObject pauseMenu = null;
        [SerializeField]
        private GameObject gameOverMenu = null;
        [SerializeField]
        private Text gameOverYourScoreText = null;
        [SerializeField]
        private Text gameOverBestScoreText = null;
        [SerializeField]
        private AudioSource buttonSound = null;
        [SerializeField]
        private Toggle vibrationToggle = null;
        [SerializeField]
        private Slider volumeSlider = null;
        [SerializeField]
        private Text shopMenuNumberOfDiamonds = null;

        void Awake()
        {
            numberOfDiamonds.text = "" + PlayerPrefs.GetInt("NumberOfDiamonds");
            GameObject.Find("GameManager").GetComponent<CreateNewGameArea>().NewGameArea(-11.31f);
            RandomRoadColor();
        }

        private void RandomRoadColor()
        {
            int randColor = Random.Range(1, 6);
            if (randColor == 1)
            {
                Vars.roadColor = new Color32(234, 79, 94, 255);
            }
            else if (randColor == 2)
            {
                Vars.roadColor = new Color32(246, 195, 72, 255);
            }
            else if (randColor == 3)
            {
                Vars.roadColor = new Color32(64, 231, 185, 255);
            }
            else if (randColor == 4)
            {
                Vars.roadColor = new Color32(254, 138, 27, 255);
            }
            else if (randColor == 5)
            {
                Vars.roadColor = new Color32(70, 183, 171, 255);
            }
        }

        public void ShowStatsMenu()
        {
            statsMenu.SetActive(true);
            buttonSound.Play();
        }

        public void HideStatsMenu()
        {
            statsMenu.SetActive(false);
            buttonSound.Play();
        }

        public void ShowShopMenu()
        {
            shopMenu.SetActive(true);
            shopMenuNumberOfDiamonds.text = "" + PlayerPrefs.GetInt("NumberOfDiamonds");
            buttonSound.Play();
        }

        public void HideShopMenu()
        {
            shopMenu.SetActive(false);
            numberOfDiamonds.text = "" + PlayerPrefs.GetInt("NumberOfDiamonds");
            buttonSound.Play();
        }

        public void ShowGiftMenu()
        {
            giftMenu.SetActive(true);
            buttonSound.Play();
        }

        public void HideGiftMenu()
        {
            giftMenu.SetActive(false);
            giftMenuDiamondImage.SetActive(false);
            numberOfDiamonds.text = "" + PlayerPrefs.GetInt("NumberOfDiamonds");
            buttonSound.Play();
        }

        public void ShowSettingsMenu()
        {
            settingsMenu.SetActive(true);
            buttonSound.Play();
        }

        public void HideSettingsMenu()
        {
            settingsMenu.SetActive(false);
            buttonSound.Play();
        }

        public void SetVolume()
        {
            AudioListener.volume = volumeSlider.value;
        }

        public void SetVibration()
        {
            if (vibrationToggle.isOn)
            {
                PlayerPrefs.SetInt("Vibration", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Vibration", 0);
            }
            buttonSound.Play();
        }

        public void StartTheGame()
        {
            carMovement.enabled = true;
            carRotation.enabled = true;
            mainMenu.GetComponent<MenuTransitionAnimation>().enabled = true;
            gameplayMenu.SetActive(true);
            gameplayMenu.GetComponent<MenuTransitionAnimation>().enabled = true;
            PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
            buttonSound.Play();
        }

        public void BackToTheMainMenuTransitionAnimation()
        {
            Time.timeScale = 1;
            if (carMovement != null)
                carMovement.enabled = false;
            if (carRotation != null)
                carRotation.enabled = false;
            GameObject.Find("GameManager").GetComponent<MenuFadeInFadeOutAnimation>().menu = 1;
            GameObject.Find("GameManager").GetComponent<MenuFadeInFadeOutAnimation>().enabled = true;
            buttonSound.Play();
        }

        public void BackToTheMainMenu()
        {
            Time.timeScale = 1;
            Vars.score = 0;
            mainMenu.SetActive(true);
            mainMenu.GetComponent<MenuTransitionAnimation>().enabled = false;
            GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            gameplayMenu.GetComponent<CanvasGroup>().alpha = 0;
            numberOfDiamonds.text = "" + PlayerPrefs.GetInt("NumberOfDiamonds");
            gameplayMenu.SetActive(false);
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            for (int i = 0; i <= Vars.gameAreaObjectsCount; i++)
            {
                if (GameObject.Find("GameArea" + i))
                    Destroy(GameObject.Find("GameArea" + i));
            }
            Vars.gameAreaObjectsCount = 1;

            GameObject.Find("GameManager").GetComponent<CreateNewGameArea>().NewGameArea(-11.31f);

            if (GameObject.Find("Car"))
                Destroy(GameObject.Find("Car"));

            GameObject car = Instantiate(Resources.Load("Car") as GameObject);
            car.transform.position = new Vector2(0, 0);
            car.gameObject.name = "Car";
            carMovement = car.GetComponent<CarMovement>();
            carRotation = car.GetComponent<CarRotation>();

            Camera.main.GetComponent<CameraFollow>().car = car;
            RandomRoadColor();
            GameObject.Find("StartRoad").GetComponent<RoadColor>().ChangeTheRoadColor();
        }

        public void ReplayTheGameTransitionAnimation()
        {
            Time.timeScale = 1;
            if (carMovement != null)
                carMovement.enabled = false;
            if (carRotation != null)
                carRotation.enabled = false;
            GameObject.Find("GameManager").GetComponent<MenuFadeInFadeOutAnimation>().menu = 0;
            GameObject.Find("GameManager").GetComponent<MenuFadeInFadeOutAnimation>().enabled = true;
            buttonSound.Play();
        }

        public void ReplayTheGame()
        {
            BackToTheMainMenu();
            carMovement.enabled = true;
            carRotation.enabled = true;
            mainMenu.GetComponent<MenuTransitionAnimation>().enabled = true;
            gameplayMenu.SetActive(true);
            gameplayMenu.GetComponent<MenuTransitionAnimation>().enabled = true;
            PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
            mainMenu.SetActive(false);
        }

        public void ShowPauseMenu()
        {
            Time.timeScale = 0;
            gameplayMenu.SetActive(false);
            pauseMenu.SetActive(true);
            carRotation.enabled = false;
            buttonSound.Play();
        }

        public void HidePauseMenu()
        {
            Time.timeScale = 1;
            gameplayMenu.SetActive(true);
            pauseMenu.SetActive(false);
            carRotation.enabled = true;
            buttonSound.Play();
        }

        public void GameOver()
        {
            if (GameObject.Find("SteeringWheel"))
                GameObject.Find("SteeringWheel").GetComponent<SteeringWheel>().ResetAll();
            gameplayMenu.SetActive(false);
            gameOverYourScoreText.text = "YOUR SCORE: " + (int)Vars.score;
            PlayerPrefs.SetInt("LastScore", (int)Vars.score);
            if ((int)Vars.score > PlayerPrefs.GetInt("BestScore"))
                PlayerPrefs.SetInt("BestScore", (int)Vars.score);
            gameOverBestScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore");
            Invoke("ShowGameOverMenu", 1.2f);
        }

        private void ShowGameOverMenu()
        {
            gameOverMenu.SetActive(true);
        }
        
        public void AddDiamonds(int value)
        {
            IAPManager.OnPurchaseSuccess = () =>
            {
                PlayerPrefs.SetInt("NumberOfDiamonds", PlayerPrefs.GetInt("NumberOfDiamonds", 0) + value);
                GameObject.Find("ShopMenuNumberOfDiamondsText").GetComponent<Text>().text = 
                    "" + PlayerPrefs.GetInt("NumberOfDiamonds", 0);
            };

            switch (value)
            {
                case 20:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                    break;
                case 50:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                    break;
                case 100:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                    break;
                case 200:
                    IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                    break;
            }
        }
    }

}

