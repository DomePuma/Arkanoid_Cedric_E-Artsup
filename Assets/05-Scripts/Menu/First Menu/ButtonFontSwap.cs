using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BrickBreaker.Menu.Font
{
    [RequireComponent(typeof(Button))]
    public class ButtonFontSwap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [Header("Font Assets")]
        [SerializeField] private TMP_FontAsset _normalFontAsset;
        [SerializeField] private TMP_FontAsset _highlightedFontAsset;

        [Header("Font Sizes")]
        [SerializeField] private float _normalFontSize;
        [SerializeField] private float _highlightedFontSize;

        private TMP_Text _tmpText;
        private bool _isPointerOver = false;
        private bool _isSelected = false;

        private void Awake()
        {
            _tmpText = GetComponentInChildren<TMP_Text>();
            if (_tmpText != null)
            {
                _tmpText.font = _normalFontAsset;
                _tmpText.fontSize = _normalFontSize;
            }
        }

        private void UpdateVisual()
        {
            if (_tmpText == null) return;

            if ((_isPointerOver || _isSelected) && _highlightedFontAsset != null)
            {
                _tmpText.font = _highlightedFontAsset;
                _tmpText.fontSize = _highlightedFontSize;
            }
            else
            {
                _tmpText.font = _normalFontAsset;
                _tmpText.fontSize = _normalFontSize;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOver = true;
            UpdateVisual();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOver = false;
            UpdateVisual();
        }

        public void OnSelect(BaseEventData eventData)
        {
            _isSelected = true;
            UpdateVisual();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _isSelected = false;
            UpdateVisual();
        }
    }
}