using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Controllers;

namespace Game.UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        private void Awake() => Instance = this;

        [SerializeField]
        private GameObject gamePanel;
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Text healthText;
        [SerializeField]
        private GameObject gameOverPanel;

        public void ChangeScore()
        {
            scoreText.text = GameController.Instance.LevelValues.score.ToString();
        }

        public void ChangeHealth(float health)
        {
            health = Mathf.Clamp(health, 0, health);
            healthText.text = "HP: " + health.ToString("0");
        }

        public void ShowGameOverPanel()
        {
            gamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}