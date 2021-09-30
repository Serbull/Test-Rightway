using Gameplay.ShipSystems;
using UnityEngine;
using Gameplay.Helpers;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private SpriteRenderer _representation;

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            if (IsInCorner())
                return;
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }

        private bool IsInCorner()
        {
            bool result;
            float axis = Input.GetAxis("Horizontal");

            if (axis < 0)
            {
                result = transform.position.x <= GameAreaHelper.LeftCornerPosition(_representation.bounds);
                if (result)
                    transform.position = new Vector2(GameAreaHelper.LeftCornerPosition(_representation.bounds), transform.position.y);
            }
            else
            {
                result = transform.position.x >= GameAreaHelper.RightCornerPosition(_representation.bounds);
                if (result)
                    transform.position = new Vector2(GameAreaHelper.RightCornerPosition(_representation.bounds), transform.position.y);
            }

            return result;
        }
    }
}
