using IJunior.TypedScenes;
using UnityEngine;

public class GalleryStarter : Starter, ISceneLoadHandler<GalleryData>
{
    [SerializeField] private TexturesDisplayerEmitter _textureDisplayerEmitter;
    [SerializeField] private TexturesSubloaderEmitter _texturesSubloaderEmitter;

    private GalleryData _galleryData;
    private TexturesDisplayer _texturesDisplayer;

    public void OnSceneLoaded(GalleryData galleryData)
    {
        _galleryData = galleryData;
    }

    protected override void OnStart()
    {
        WebTexturesProvider webTexturesProvider = new WebTexturesProvider(WebConstants.TexturesUrl);
        _texturesDisplayer = Register(new TexturesDisplayer(_galleryData.StartTextures, 
            _textureDisplayerEmitter));
        TexturesSubloader texturesSubloader = Register(new TexturesSubloader(webTexturesProvider, _texturesDisplayer, 
            _texturesSubloaderEmitter));
        PreviewLoader previewLoader = Register(new PreviewLoader(_texturesDisplayer));
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < _texturesDisplayer.Textures.Count; i++)
        {
            Destroy(_texturesDisplayer.Textures[i]);
        }
    }
}
