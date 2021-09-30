using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Controllers;

namespace Game.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Button restartButton;

        void Start()
        {
            scoreText.text = "Score: " + GameController.Instance.LevelValues.score;
            restartButton.onClick.AddListener(GameController.Instance.RestartLevel);
        }

    }
}