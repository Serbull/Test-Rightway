using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;
namespace Gameplay.Bonuses
{
    public class Health : Bonus, ISelected
    {
        [SerializeField]
        private int _addHealth;

        public void Take(Spaceship spaceship)
        {
            Destroy(gameObject);
            spaceship.AddHealth(_addHealth);
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
    }
}