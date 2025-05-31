using UnityEngine;

public class CreditRoll : MonoBehaviour
{
    [Header("Scroll Settings")]
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _endPositionY = 800f;

    [Header("Timing")]
    [SerializeField] private float _delayBeforeStart = 2f;

    private RectTransform _creditsParent;
    private float timer = 0f;
    private bool isScrolling = false;

    private float _initialPositionY;

    private void Awake()
    {
        _creditsParent = GetComponent<RectTransform>();
    }

    void Start()
    {
        _initialPositionY = _creditsParent.anchoredPosition.y;

        Vector2 pos = _creditsParent.anchoredPosition;
        pos.y = _initialPositionY;
        _creditsParent.anchoredPosition = pos;
    }

    void Update()
    {
        if (!isScrolling)
        {
            timer += Time.deltaTime;
            if (timer >= _delayBeforeStart)
            {
                isScrolling = true;
            }
        }
        else
        {
            _creditsParent.anchoredPosition += Vector2.up * _speed * Time.deltaTime;

            if (_creditsParent.anchoredPosition.y >= _endPositionY)
            {
                Vector2 pos = _creditsParent.anchoredPosition;

                pos.y = _initialPositionY;
                _creditsParent.anchoredPosition = pos;

                isScrolling = false;
                timer = 0f;
            }
        }
    }
}