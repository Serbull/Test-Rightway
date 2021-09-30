using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private Projectile _projectile;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;


        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;


        private float energyMultiplier = 1;
        
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        
        
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }


        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown / energyMultiplier);
            _readyToFire = true;
        }

        public void AddEnergy(float time)
        {
            StartCoroutine(EnergyMultiplier(time));
        }

        private IEnumerator EnergyMultiplier(float time)
        {
            energyMultiplier = 2;
            yield return new WaitForSeconds(time);
            energyMultiplier = 1;
        }

    }
}
