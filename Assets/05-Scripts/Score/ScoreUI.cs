using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace BrickBreaker.Score.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private ScoreSystem _scoreSystem;

        private void OnEnable()
        {
            _scoreSystem.OnScoreChanged += UpdateScoreUI;
            _scoreText.text = "Score: 0";
        }

        public void UpdateScoreUI(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}