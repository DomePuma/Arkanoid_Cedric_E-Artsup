using System;
using UnityEngine;

namespace BrickBreaker.PowerUp.Base
{
    public class PowerUpMultiBall : APowerUp
    {
        public event Action<int> OnPowerUpClaimed;

        public override void Claim()
        {
            
        }
    }
}