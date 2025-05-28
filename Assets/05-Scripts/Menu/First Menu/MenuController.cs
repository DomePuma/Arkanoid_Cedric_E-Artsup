using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrickBreaker.Menu.ChangeScene
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private string _gameSceneName;

        public void PlayGame()
        {
            SceneManager.LoadScene(_gameSceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}