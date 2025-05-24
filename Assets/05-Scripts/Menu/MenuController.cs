using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string optionsSceneName = "OptionsMenuScene";

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        if (!SceneManager.GetSceneByName(optionsSceneName).isLoaded)
        {
            SceneManager.LoadScene(optionsSceneName, LoadSceneMode.Additive);
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