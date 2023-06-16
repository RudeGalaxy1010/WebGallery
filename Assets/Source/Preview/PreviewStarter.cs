using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class PreviewStarter : Starter, ISceneLoadHandler<PreviewData>
{
    [SerializeField] private TexturesDisplayerEmitter _texturesDisplayerEmitter;

    private PreviewData _previewData;

    public void OnSceneLoaded(PreviewData previewData)
    {
        _previewData = previewData;
    }

    protected override void OnStart()
    {
        List<Texture> texturesToDisplay = new List<Texture>() { _previewData.PreviewTexture };
        TexturesDisplayer texturesDisplayer = Register(new TexturesDisplayer(texturesToDisplay,
            _texturesDisplayerEmitter));
    }
}
