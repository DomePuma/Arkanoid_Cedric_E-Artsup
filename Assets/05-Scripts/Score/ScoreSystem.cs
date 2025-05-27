using ScoreObserverPattern;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private ScoreData _scoreData;
    [SerializeField] private UnityEvent<int> _onScoreChanged;

    public void AddScore(int value)
    {
        int newScore = _scoreData.Score + value;
        _scoreData.SetScore(newScore);
        _onScoreChanged.Invoke(newScore);
    }

    public void ResetScore()
    {
        _scoreData.SetScore(0);
        _onScoreChanged.Invoke(0);
    }
}
