namespace BrickBreaker.Score
{
    public interface IScoreManager
    {
        int Score { get; }
        void AddScore(int score);
        void RemoveScore(int score);
        void ResetScore();
    }
}