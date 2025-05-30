using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker.Spawning
{
    public class PowerUpSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _powerUpList = new List<GameObject>();
        public void SpawnPowerUp(Vector3 spawnPosition)
        {
            if (Random.Range(0, 2) == 0 && _powerUpList.Count > 0)
            {
                int randomIndex = Random.Range(0, _powerUpList.Count);
                GameObject randomPowerUp = _powerUpList[randomIndex];

                Instantiate(randomPowerUp, spawnPosition, Quaternion.identity);
                Debug.Log("PowerUp Spwaned");
            }
            else if(Random.Range(0, 10) != 0 && _powerUpList.Count > 0)
            {
                Debug.LogWarning("No PowerUp Spawned 1/10 chances tho :/");
            }
            else if( _powerUpList.Count <= 0 )
            {
                Debug.LogError("No Power Ups In Power Up Spawner");
            }
        }

    }
}