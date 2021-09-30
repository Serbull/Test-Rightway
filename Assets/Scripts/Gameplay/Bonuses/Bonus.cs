using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Weapons;
using Gameplay.Spaceships;
namespace Gameplay.Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        void Update()
        {
            Move(_speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var spaceship = other.gameObject.GetComponent<Spaceship>();
            if (spaceship != null && spaceship.BattleIdentity == UnitBattleIdentity.Ally)
            {
                GetComponent<ISelected>().Take(spaceship);
            }
        }

        protected abstract void Move(float speed);

    }
}