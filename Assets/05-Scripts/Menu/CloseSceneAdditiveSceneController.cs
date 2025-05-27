using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseSceneAdditiveSceneController : MonoBehaviour
{
    public void CloseSceneAdditive()
    {
        Scene currentScene = gameObject.scene;
        SceneManager.UnloadSceneAsync(currentScene);
    }
}