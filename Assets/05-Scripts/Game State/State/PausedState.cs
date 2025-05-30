using UnityEngine;

namespace BrickBreaker.GameStateSystem.State
{
    public class PausedState : IGameState
    {
        private GameObject _pauseCanvas;
        private bool _canUnpause = false;

        public PausedState(GameObject pauseCanvas)
        {
            _pauseCanvas = pauseCanvas;
        }

        public void EnterState(GameState gameState)
        {
            if (_pauseCanvas == null)
            {
                Debug.LogError("PauseCanvas non assigné !");
                return;
            }

            Time.timeScale = 0f;
            Debug.Log("État : Pause");

            _pauseCanvas.SetActive(true);

            _canUnpause = false;
            gameState.StartCoroutine(AllowUnpauseNextFrame());
        }

        public void UpdateState(GameState gameState) { }

        public void ExitState(GameState gameState)
        {
            Time.timeScale = 1f;
            _pauseCanvas?.SetActive(false);
        }

        public void OnClosePauseInput(GameState gameState)
        {
            if (!_canUnpause) return;

            gameState.SetState(gameState.BallLaunched);
        }

        private System.Collections.IEnumerator AllowUnpauseNextFrame()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            _canUnpause = true;
        }
    }
}