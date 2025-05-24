using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string _gameSceneName = "GameScene";
    [SerializeField] private string _optionsSceneName = "OptionsMenuScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

    public void OpenOptions()
    {
        if (!SceneManager.GetSceneByName(_optionsSceneName).isLoaded)
        {
            SceneManager.LoadScene(_optionsSceneName, LoadSceneMode.Additive);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}