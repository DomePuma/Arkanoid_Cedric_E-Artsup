using UnityEngine;
using System.Collections.Generic;
using BrickBreaker.Brick.Factory;
using BrickBreaker.Brick;
using BrickBreaker.Spawning.Layout;
using System;

namespace BrickBreaker.Spawning
{
    public class BrickSpawner : MonoBehaviour
    {
        [Header("Layout Configuration")]
        [SerializeField] private int _rows = 6;
        [SerializeField] private int _columns = 13;
        [SerializeField] private Vector2 _startOffset = new Vector2(-6f, 4f);
        [SerializeField] private float _brickHeight = 0.5f;
        [SerializeField] private float _brickWidth = 1f;

        [Header("Bonus Brick Settings")]
        [SerializeField] private int _maxBonusPerRow = 5;

        [Header("Factory Data")]
        [SerializeField] private BrickFactoryData _brickFactoryDataInstance;

        private IBrickLayoutStrategy _layoutStrategy;

        private void Awake()
        {
            _layoutStrategy = new ArkanoidLayoutStrategy();
        }

        private void Start()
        {
            SpawnBricks();
        }

        private void SpawnBricks()
        {
            BrickType[,] layout = _layoutStrategy.GenerateLayout(_rows, _columns);

            // On supprime les bonus générés dans la layout pour les replacer selon la limite max
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    if (layout[row, col] == BrickType.Bonus)
                        layout[row, col] = BrickType.Standard;
                }
            }

            // Liste des positions Standard possibles où on pourra placer les bonus
            List<Vector2Int> standardPositions = new List<Vector2Int>();
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    if (layout[row, col] == BrickType.Standard)
                        standardPositions.Add(new Vector2Int(row, col));
                }
            }

            // On place _maxBonusPerRow bonus aléatoirement dans la grille
            int totalBonus = Mathf.Min(_maxBonusPerRow, standardPositions.Count);
            for (int i = 0; i < totalBonus; i++)
            {
                int randomIndex = UnityEngine.Random.Range(i, standardPositions.Count);
                (standardPositions[i], standardPositions[randomIndex]) = (standardPositions[randomIndex], standardPositions[i]);
                Vector2Int pos = standardPositions[i];
                layout[pos.x, pos.y] = BrickType.Bonus;
            }

            // Instanciation des briques, avec la couleur selon la ligne (même index pour Standard et Bonus)
            for (int row = 0; row < _rows; row++)
            {
                int rowPrefabIndex = row % GetPrefabCountForType(BrickType.Standard);

                for (int col = 0; col < _columns; col++)
                {
                    BrickType typeToSpawn = layout[row, col];

                    if (typeToSpawn == BrickType.Standard || typeToSpawn == BrickType.Unbreakable || typeToSpawn == BrickType.Bonus)
                    {
                        Vector3 position = new Vector3(
                            _startOffset.x + col * _brickWidth,
                            _startOffset.y - row * _brickHeight,
                            0f
                        );

                        // Ici on donne toujours rowPrefabIndex pour garder la couleur de la ligne même pour les bonus
                        BrickFactory.CreateBrick(typeToSpawn, position, rowPrefabIndex);
                    }
                }
            }
        }

        private int GetPrefabCountForType(BrickType type)
        {
            switch (type)
            {
                case BrickType.Standard:
                    return _brickFactoryDataInstance.StandardBrickPrefabList.Count;
                case BrickType.Bonus:
                    return _brickFactoryDataInstance.BonusBrickPrefabList.Count;
                default:
                    return 1;
            }
        }
    }
}