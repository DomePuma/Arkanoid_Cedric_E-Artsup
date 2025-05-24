using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private MusicType menuMusic = MusicType.Menu;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(menuMusic, true);
        }
    }
}