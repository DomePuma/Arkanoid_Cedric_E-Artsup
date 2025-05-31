using BrickBreaker.PowerUp.Data;
using BrickBreaker.Spawning.PowerUp.Strategy;
using BrickBreaker.Spawning.Strategies;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker.Spawning.PowerUp
{
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField] private List<PowerUpData> _powerUpDataList = new List<PowerUpData>();
        private IPowerUpSpawnStrategy _spawnStrategy;

        private void Awake()
        {
            _spawnStrategy = new BasicRandomSpawnStrategy();
        }

        public void SpawnPowerUp(Vector3 spawnPosition)
        {
            if (_powerUpDataList.Count <= 0)
            {
                Debug.LogError("No PowerUps configured in PowerUpSpawner.");
                return;
            }

            if (_spawnStrategy.ShouldSpawnPowerUp())
            {
                PowerUpData chosen = GetRandomWeightedPowerUp();
                if (chosen != null)
                {
                    Instantiate(chosen.prefab, spawnPosition, Quaternion.identity);
                    Debug.Log($"PowerUp Spawned: {chosen.powerUpType}");
                }
            }
            else
            {
                Debug.Log("No PowerUp Spawned (strategy said no)");
            }
        }

        private PowerUpData GetRandomWeightedPowerUp()
        {
            float totalWeight = 0f;
            foreach (var data in _powerUpDataList)
            {
                totalWeight += data.spawnChance;
            }

            float randomValue = Random.Range(0f, totalWeight);
            float currentSum = 0f;

            foreach (var data in _powerUpDataList)
            {
                currentSum += data.spawnChance;
                if (randomValue <= currentSum)
                {
                    return data;
                }
            }

            return null; // fallback, should not happen
        }

        public void SetSpawnStrategy(IPowerUpSpawnStrategy strategy)
        {
            _spawnStrategy = strategy;
        }
    }
}
