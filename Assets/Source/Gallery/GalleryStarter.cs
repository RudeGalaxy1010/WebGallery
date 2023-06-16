using IJunior.TypedScenes;
using UnityEngine;

public class GalleryStarter : Starter, ISceneLoadHandler<GalleryData>
{
    [SerializeField] private TextureDisplayerEmitter _textureDisplayerEmitter;
    [SerializeField] private TexturesSubloaderEmitter _texturesSubloaderEmitter;

    private GalleryData _galleryData;

    public void OnSceneLoaded(GalleryData galleryData)
    {
        _galleryData = galleryData;
    }

    protected override void OnStart()
    {
        WebTexturesProvider webTexturesProvider = new WebTexturesProvider(WebConstants.TexturesUrl);
        TexturesDisplayer texturesDisplayer = new TexturesDisplayer(_galleryData.StartTextures, _textureDisplayerEmitter);
        TexturesSubloader texturesSubloader = Register(new TexturesSubloader(webTexturesProvider, texturesDisplayer, 
            _texturesSubloaderEmitter));
    }
}
