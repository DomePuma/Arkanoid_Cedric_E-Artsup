using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreUI(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}