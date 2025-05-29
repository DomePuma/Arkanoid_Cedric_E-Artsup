using BrickBreaker.Ball.Spawner;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] _heartImages;
    [SerializeField] private BallSpawner _ballSpawner;

    private float _lostOpacity = 0.22f;
    private int _currentLives;
    private int _lostLives = 0;

    public event Action OnGameOver;

    private void Start()
    {
        _currentLives = _heartImages.Length;

        foreach (Image heart in _heartImages)
            SetAlpha(heart, 1f);
    }

    public void LoseLife()
    {
        if (_lostLives >= _heartImages.Length)
            return;

        SetAlpha(_heartImages[_lostLives], _lostOpacity);
        _lostLives++;
        _currentLives--;

        if (_currentLives > 0)
        {
            _ballSpawner.SpawnBall();
        }
        else
        {
            Debug.Log("Game Over!");
            OnGameOver?.Invoke();
        }
    }

    private void SetAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}