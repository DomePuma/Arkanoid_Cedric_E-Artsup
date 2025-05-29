using UnityEngine;
using BrickBreaker.Audio.Music.Type;

namespace BrickBreaker.Audio.Music
{
    public class MenuMusic : MonoBehaviour
    {
        [SerializeField] private MusicType _menuMusic = MusicType.Menu;

        void Start()
        {
            if (AudioSystem.Instance != null)
            {
                AudioSystem.Instance.PlayMusic(_menuMusic, true);
            }
        }
    }
}