using System.Collections.Generic;
using UnityEngine;

public class TexturesDisplayer : IDeinitable
{
    private List<Texture> _textures;
    private TextureDisplayerEmitter _emitter;
    private List<TextureItem> _textureItems;

    public TexturesDisplayer(List<Texture> startTextures, TextureDisplayerEmitter emitter)
    {
        _textures = startTextures;
        _emitter = emitter;
        _textureItems = new List<TextureItem>();
        UpdateTextures();
    }

    public int TexturesDisplayed => _textureItems.Count;

    public void Deinit()
    {
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
        _textureItems.Add(textureItem);
        return textureItem;
    }
}
