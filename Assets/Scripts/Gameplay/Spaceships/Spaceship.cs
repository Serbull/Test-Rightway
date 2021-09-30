using System;
using Game.Controllers;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private float _health;


        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
            if (_battleIdentity == UnitBattleIdentity.Ally)
            {
                GameController.Instance.OnChangeHealth(_health);
            }
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _health -= damageDealer.Damage;
            if(_battleIdentity == UnitBattleIdentity.Ally)
            {
                GameController.Instance.OnChangeHealth(_health);
            }
            if (_health <= 0)
            {
                Destroy(gameObject);
                GameController.Instance.OnDestroyShip(_battleIdentity);
            }
        }

    }
}
