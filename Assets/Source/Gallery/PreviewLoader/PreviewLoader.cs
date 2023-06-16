using IJunior.TypedScenes;
using UnityEngine;

public class PreviewLoader : IInitable, IDeinitable
{
    private TexturesDisplayer _texturesDisplayer;

    public PreviewLoader(TexturesDisplayer texturesDisplayer)
    {
        _texturesDisplayer = texturesDisplayer;
    }

    public void Init()
    {
        _texturesDisplayer.OnTextureSelect += OnTextureSelected;
    }

    public void Deinit()
    {
        _texturesDisplayer.OnTextureSelect -= OnTextureSelected;
    }

    private void OnTextureSelected(Texture texture)
    {
        LoadPreview(texture);
    }

    private void LoadPreview(Texture previewTexture)
    {
        PreviewData previewData = new PreviewData()
        {
            LoadedTextures = _texturesDisplayer.Textures,
            PreviewTexture = previewTexture
        };
        PreviewScene.Load(previewData);
    }
}
