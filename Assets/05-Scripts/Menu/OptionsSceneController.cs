using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsSceneController : MonoBehaviour
{
    public void CloseOptionsMenu()
    {
        Scene currentScene = gameObject.scene;
        SceneManager.UnloadSceneAsync(currentScene);
    }
}