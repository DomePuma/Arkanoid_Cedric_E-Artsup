using BrickBreaker.Spawning.PowerUp.Strategy;
using UnityEngine;

namespace BrickBreaker.Spawning.Strategies
{
    public class BasicRandomSpawnStrategy : IPowerUpSpawnStrategy
    {

        public bool ShouldSpawnPowerUp()
        {
            return Random.Range(0, 10) == 0;
        }

        public int ChoosePowerUpIndex(int count)
        {
            return Random.Range(0, count);
        }
    }
}
