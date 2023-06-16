using System;
using UnityEngine;
using UnityEngine.UI;

public class TextureItem : MonoBehaviour
{
    public event Action<Texture> OnClick;

    [SerializeField] private RawImage _rawImage;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void SetTexture(Texture texture)
    {
        _rawImage.texture = texture;
    }

    private void OnButtonClicked()
    {
        OnClick?.Invoke(_rawImage.texture);
    }
}
