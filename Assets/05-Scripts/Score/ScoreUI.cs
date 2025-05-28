using TMPro;
using UnityEngine;

namespace BrickBreaker.Score.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScoreUI(int score)
        {
            _scoreText.text = $"ScoreObserver: {score}";
        }
    }
}