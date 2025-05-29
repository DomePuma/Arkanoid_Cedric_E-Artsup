using System;
using UnityEngine;
using BrickBreaker.Score.Data;

namespace BrickBreaker.Score
{
    public class ScoreManager : IScoreManager
    {
        private ScoreData _scoreData;

        public ScoreManager(ScoreData scoreData)
        {
            _scoreData = scoreData;
        }

        public int Score => _scoreData.Score;

        public void AddScore(int score)
        {
            _scoreData.Score = _scoreData.Score + score;
            Console.WriteLine($"Score mis à jour : {_scoreData.Score}");
        }

        public void RemoveScore(int score)
        {
            _scoreData.Score = _scoreData.Score - score;
            Console.WriteLine($"Score décrémenté : {_scoreData.Score}");
        }

        public void ResetScore()
        {
            _scoreData.Score = 0;
            Console.WriteLine("Score réinitialisé.");
        }
    }
}