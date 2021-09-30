using UnityEngine;
using Gameplay.Spaceships;
namespace Gameplay.Bonuses
{
    public class Energy : Bonus, ISelected
    {
        [SerializeField]
        private float _energyTime;

        public void Take(Spaceship spaceship)
        {
            Destroy(gameObject);
            spaceship.AddEnergy(_energyTime);
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
    }
}