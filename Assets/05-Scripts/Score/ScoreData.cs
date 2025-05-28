using UnityEngine;

namespace BrickBreaker.Score.Data
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Object/ScoreObserver Data")]
    public class ScoreData : ScriptableObject
    {
        [SerializeField] private int _score;

        public int Score => _score;

        public void SetScore(int value)
        {
            _score = value;
        }
    }
}