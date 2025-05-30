using TMPro;
using UnityEngine;

namespace BrickBreaker.Score.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private ScoreSystem _scoreSystem;

        private void Awake()
        {
            _scoreSystem = FindFirstObjectByType<ScoreSystem>();
        }

        private void OnEnable()
        {
            _scoreSystem.OnScoreChanged += UpdateScoreUI;
        }

        public void UpdateScoreUI(int score)
        {
            _scoreText.text = $"{score}";
        }
    }
}