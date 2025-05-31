using System;

namespace BrickBreaker.PowerUp.Base
{
    public class PowerUpDestroyAnyBricksBall : APowerUp
    {
        public event Action<int> OnPowerUpClaimed;

        public override void Claim()
        {

        }
    }
}