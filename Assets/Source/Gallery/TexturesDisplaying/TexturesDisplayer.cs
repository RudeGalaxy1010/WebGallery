using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class TexturesDisplayer : IDeinitable
{
    public event Action<Texture> OnTextureSelect;

    private List<Texture> _textures;
    private TexturesDisplayerEmitter _emitter;
    private List<TextureItem> _textureItems;

    private bool _textureSelected;

    public TexturesDisplayer(List<Texture> startTextures, TexturesDisplayerEmitter emitter)
    {
        _textures = startTextures;
        _emitter = emitter;
        _textureItems = new List<TextureItem>();
        _textureSelected = false;
        UpdateTextures();
    }

    public int TexturesDisplayed => _textureItems.Count;
    public List<Texture> Textures => _textures;

    public void Deinit()
    {
        for (int i = 0; i < _textureItems.Count; i++)
        {
            _textureItems[i].OnClick -= OnTextureItemClicked;
        }

        if (_textureSelected == true)
        {
            return;
        }

        for (int i = 0; i < _textures.Count; i++)
        {
            Object.Destroy(_textures[i]);
        }
    }

    public void AddTextures(List<Texture> textures)
    {
        _textures.AddRange(textures);
        UpdateTextures();
    }

    private void UpdateTextures()
    {
        for (int i = 0; i < _textures.Count; i++)
        {
            TextureItem textureItem = i < _textureItems.Count ? _textureItems[i] : CreateTextureItem();
            textureItem.SetTexture(_textures[i]);
        }
    }

    private TextureItem CreateTextureItem()
    {
        TextureItem textureItem = Object.Instantiate(_emitter.TextureItemPrefab, _emitter.TextureItemsContainer);
        textureItem.OnClick += OnTextureItemClicked;
        _textureItems.Add(textureItem);
        return textureItem;
    }

    private void OnTextureItemClicked(Texture texture)
    {
        _textureSelected = true;
        OnTextureSelect?.Invoke(texture);
    }
}
