using UnityEngine;

public class MenuStarter : Starter
{
    [SerializeField] private ProgressBarEmitter _progressBarEmitter;
    [SerializeField] private GalleryLoaderEmitter _galleryLoaderEmitter;

    protected override void OnStart()
    {
        WebTexturesProvider picturesProvider = new WebTexturesProvider(WebConstants.TexturesUrl);
        ProgressBar progressBar = new ProgressBar(_progressBarEmitter);
        GalleryLoader galleryLoader = Register(new GalleryLoader(picturesProvider, progressBar, _galleryLoaderEmitter));
    }
}
