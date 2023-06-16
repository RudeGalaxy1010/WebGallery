using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class PreviewStarter : Starter, ISceneLoadHandler<PreviewData>
{
    [SerializeField] private TexturesDisplayerEmitter _texturesDisplayerEmitter;
    [SerializeField] private BackGalleryLoaderEmitter _backGalleryLoaderEmitter;

    private PreviewData _previewData;
    private TexturesDisplayer _texturesDisplayer;

    public void OnSceneLoaded(PreviewData previewData)
    {
        _previewData = previewData;
    }

    protected override void OnStart()
    {
        List<Texture> texturesToDisplay = new List<Texture>() { _previewData.PreviewTexture };
        _texturesDisplayer = Register(new TexturesDisplayer(texturesToDisplay,
            _texturesDisplayerEmitter));
        BackGalleryLoader backGalleryLoader = Register(new BackGalleryLoader(_previewData, _backGalleryLoaderEmitter));
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < _texturesDisplayer.Textures.Count; i++)
        {
            Destroy(_texturesDisplayer.Textures[i]);
        }
    }
}
