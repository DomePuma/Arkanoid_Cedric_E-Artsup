using UnityEngine;
using System;
using BrickBreaker.Score.Data;

namespace BrickBreaker.Score
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private ScoreData _scoreData;

        public event Action<int> OnScoreChanged;

        private IScoreManager _scoreManager;

        private void Awake()
        {
            _scoreManager = new ScoreManager(_scoreData);
            _scoreManager.ResetScore();
        }

        public void AddScore(int value)
        {
            Debug.Log("AddScore");
            _scoreManager.AddScore(value);
            OnScoreChanged?.Invoke(_scoreManager.Score);
        }

        public void RemoveScore(int value)
        {
            _scoreManager.RemoveScore(value);
            OnScoreChanged?.Invoke(_scoreManager.Score);
        }

        public void ResetScore()
        {
            _scoreManager.ResetScore();
            OnScoreChanged?.Invoke(_scoreManager.Score);
        }
    }
}
