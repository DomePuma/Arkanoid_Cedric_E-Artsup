using UnityEngine;

namespace BrickBreaker.Score.Data
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Object/ScoreObserver Data")]
    public class ScoreData : ScriptableObject
    {
        [SerializeField] private int _score = 0;

        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
}