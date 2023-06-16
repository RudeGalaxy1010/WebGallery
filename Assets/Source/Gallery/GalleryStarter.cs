using IJunior.TypedScenes;
using UnityEngine;

public class GalleryStarter : Starter, ISceneLoadHandler<GalleryData>
{
    [SerializeField] private TextureDisplayerEmitter _textureDisplayerEmitter;

    private GalleryData _galleryData;

    public void OnSceneLoaded(GalleryData galleryData)
    {
        _galleryData = galleryData;
    }

    protected override void OnStart()
    {
        WebTexturesProvider webTexturesProvider = new WebTexturesProvider(WebConstants.TexturesUrl);
        TexturesDisplayer texturesDisplayer = new TexturesDisplayer(_galleryData.StartTextures, _textureDisplayerEmitter);
    }
}
