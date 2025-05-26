using UnityEngine;

namespace BrickBreaker.Menu.Title
{
    [RequireComponent(typeof(RectTransform))]
    public class TitleFloating : MonoBehaviour
    {
        [Header("Amplitude du mouvement")]
        [SerializeField] private float _amplitudeX;
        [SerializeField] private float _amplitudeY;

        [Header("Vitesse du mouvement")]
        [SerializeField] private float _frequencyX;
        [SerializeField] private float _frequencyY;

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
}