using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class BonusController: MonoBehaviour
    {
        public static BonusController Instance;

        private void Awake() => Instance = this;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private Bonus[] _bonuses;

        public void CalculateBonus(Vector3 position)
        {
            bool spawn = Random.Range(0, 10) > 7;
            if(spawn)
            {
                int bonusId = Random.Range(0, _bonuses.Length);
                SpawnBonus(bonusId, position);
            }
        }

        private void SpawnBonus(int id, Vector3 position)
        {
            Instantiate(_bonuses[id], position, transform.rotation, _parent);
        }
    }
}
