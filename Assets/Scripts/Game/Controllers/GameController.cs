using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Gameplay.Weapons;
using UnityEngine.SceneManagement;
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

        public void OnDestroyShip(UnitBattleIdentity _battleIdentity)
        {
            switch(_battleIdentity)
            {
                case UnitBattleIdentity.Enemy:
                    _levelValues.score++;
                    UIController.Instance.ChangeScore();
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