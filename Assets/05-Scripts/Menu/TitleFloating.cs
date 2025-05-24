using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TitleFloating : MonoBehaviour
{
    [Header("Amplitude du mouvement")]
    [SerializeField] private float _amplitudeX = 3f;
    [SerializeField] private float _amplitudeY = 5f;

    [Header("Vitesse du mouvement")]
    [SerializeField] private float _frequencyX = 0.8f;
    [SerializeField] private float _frequencyY = 1.2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float waveX = Mathf.Sin(Time.time * _frequencyX) * _amplitudeX;
        float waveY = Mathf.Cos(Time.time * _frequencyY) * _amplitudeY;

        transform.localPosition = startPos + new Vector3(waveX, waveY, 0);
    }
}