using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TexturesSubloader : IInitable, IDeinitable
{
    private const int TexturesPerLoad = 2;

    private WebTexturesProvider _webTexturesProvider;
    private TexturesDisplayer _texturesDisplayer;
    private TexturesSubloaderEmitter _emitter;

    private bool _subloadingInProgress;
    private bool _allPicturesLoaded;

    public TexturesSubloader(WebTexturesProvider webTexturesProvider, TexturesDisplayer texturesDisplayer,
        TexturesSubloaderEmitter emitter)
    {
        _webTexturesProvider = webTexturesProvider;
        _texturesDisplayer = texturesDisplayer;
        _emitter = emitter;
    }

    public void Init()
    {
        _emitter.ScrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
    }

    public void Deinit()
    {
        _emitter.ScrollRect.onValueChanged.RemoveListener(OnScrollRectValueChanged);
    }

    private void OnScrollRectValueChanged(Vector2 scrollPosition)
    {
        if (_subloadingInProgress == true || _allPicturesLoaded == true)
        {
            return;
        }

        if (scrollPosition.y <= 0)
        {
            _subloadingInProgress = true;
            SubloadTextures(TexturesPerLoad);
        }
    }

    private void SubloadTextures(int texturesCount)
    {
        _emitter.StartCoroutine(_webTexturesProvider.TryLoadTextures(texturesCount, UpdateTextures,
            firstTextureOrderNumber: _texturesDisplayer.TexturesDisplayed));
    }

    private void UpdateTextures(List<Texture> textures)
    {
        textures = textures.Where(t => t != null).ToList();

        if (textures.Count == 0)
        {
            _allPicturesLoaded = true;
            return;
        }

        _texturesDisplayer.AddTextures(textures);
        _subloadingInProgress = false;
    }
}
