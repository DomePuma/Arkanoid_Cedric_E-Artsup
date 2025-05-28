using TMPro;
using UnityEngine;

namespace ScoreObserverPattern
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