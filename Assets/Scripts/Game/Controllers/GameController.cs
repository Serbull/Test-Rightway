using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine.SceneManagement;
using Gameplay.Bonuses;

namespace Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        private LevelValues _levelValues;
        public LevelValues LevelValues => _levelValues;
        
       
        private void Awake()
        {
            Instance = this;
            _levelValues = new LevelValues();
        }

        public void OnChangeHealth(float health)
        {
            UIController.Instance.ChangeHealth(health);
        }

        public void OnDestroyShip(Spaceship spaceship)
        {
            switch(spaceship.BattleIdentity)
            {
                case UnitBattleIdentity.Enemy:
                    _levelValues.score++;
                    UIController.Instance.ChangeScore();
                    BonusController.Instance.CalculateBonus(spaceship.Position);
                    break;
                case UnitBattleIdentity.Ally:
                    UIController.Instance.ShowGameOverPanel();
                    break;
            }
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}