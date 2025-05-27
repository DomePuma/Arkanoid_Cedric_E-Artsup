using UnityEngine;

namespace ScoreObserverPattern
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "Scriptable Object/Score Data")]
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