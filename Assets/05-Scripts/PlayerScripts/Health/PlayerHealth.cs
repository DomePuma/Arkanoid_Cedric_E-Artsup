using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] _heartImages;

    private float _lostOpacity = 0.22f;
    private int _currentLives;
    private int _lostLives = 0;

    private void Start()
    {
        _currentLives = _heartImages.Length;
        _lostLives = 0;

        foreach (Image heart in _heartImages)
        {
            SetAlpha(heart, 1f);
        }
    }

    public void LoseLife()
    {
        if (_lostLives >= _heartImages.Length)
            return;

        SetAlpha(_heartImages[_lostLives], _lostOpacity);

        _lostLives++;
        _currentLives--;

        if (_currentLives <= 0)
        {
            Debug.Log("Game Over!");
            // TODO: Afficher écran de Game Over
        }
    }

    private void SetAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}