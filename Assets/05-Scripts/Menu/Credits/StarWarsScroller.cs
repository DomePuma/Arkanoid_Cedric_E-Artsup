using UnityEngine;
using TMPro;

public class StarWarsScroller : MonoBehaviour
{
    [Header("Texte à faire défiler")]
    [SerializeField] private Transform textTransform;

    [Header("Défilement")]
    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float startDelay = 1f;
    [SerializeField] private float startY = -286f;
    [SerializeField] private float stopY = 60f;
    [SerializeField] private float tiltAngle = 40f;

    [Header("Effet perspective")]
    [SerializeField] private float fadeStartY = 0f;         // Position Y à partir de laquelle le texte commence à scaler
    [SerializeField] private float zEnd = 50f;
    [SerializeField] private float scaleEnd = 0.1f;

    private float timer;
    private TMP_Text[] textLines;

    private void Start()
    {
        if (textTransform == null)
        {
            Debug.LogError("Text Transform non assigné !");
            enabled = false;
            return;
        }

        timer = 0f;
        textTransform.localRotation = Quaternion.Euler(tiltAngle, 0f, 0f);
        textTransform.localPosition = new Vector3(textTransform.localPosition.x, startY, 0f);
        textTransform.localScale = Vector3.one;

        textLines = textTransform.GetComponentsInChildren<TMP_Text>(true);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer < startDelay) return;

        // Scroll le parent vers le haut
        textTransform.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

        foreach (var line in textLines)
        {
            Vector3 localPos = line.transform.localPosition;
            float worldY = line.transform.position.y;

            if (worldY >= fadeStartY)
            {
                // Applique le scale et Z si la ligne dépasse fadeStartY
                float t = Mathf.InverseLerp(fadeStartY, stopY, worldY);
                float scale = Mathf.Lerp(1f, scaleEnd, t);
                float z = Mathf.Lerp(0f, zEnd, t);

                line.transform.localScale = Vector3.one * scale;
                line.transform.localPosition = new Vector3(localPos.x, localPos.y, z);
            }
            else
            {
                // Aucun effet tant que le texte est dans la zone visible
                line.transform.localScale = Vector3.one;
                line.transform.localPosition = new Vector3(localPos.x, localPos.y, 0f);
            }
        }

        // Stop quand tout est sorti
        if (textTransform.localPosition.y >= stopY)
        {
            gameObject.SetActive(false);
        }
    }
}