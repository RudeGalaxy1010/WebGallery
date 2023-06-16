using UnityEngine;

public class MenuStarter : Starter
{
    [SerializeField] private GalleryLoaderEmitter _galleryLoaderEmitter;

    protected override void OnStart()
    {
        WebTexturesProvider picturesProvider = new WebTexturesProvider(WebConstants.TexturesUrl);
        GalleryLoader galleryLoader = Register(new GalleryLoader(picturesProvider, _galleryLoaderEmitter));
    }
}
