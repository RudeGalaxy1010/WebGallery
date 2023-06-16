using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class GalleryLoader : IInitable, IDeinitable
{
    private const int ImagesToLoadOnStart = 10;

    private WebTexturesProvider _picturesProvider;
    private ProgressBar _progressBar;
    private GalleryLoaderEmitter _emitter;

    public GalleryLoader(WebTexturesProvider picturesProvider, ProgressBar progressBar, GalleryLoaderEmitter emitter)
    {
        _picturesProvider = picturesProvider;
        _progressBar = progressBar;
        _emitter = emitter;
    }

    public void Init()
    {
        _emitter.LoadGalleryButton.onClick.AddListener(OnLoadGalleryButtonClicked);
    }

    public void Deinit()
    {
        _emitter.LoadGalleryButton.onClick.RemoveListener(OnLoadGalleryButtonClicked);
    }

    private void OnLoadGalleryButtonClicked()
    {
        _progressBar.SetVisible(true);
        _emitter.StartCoroutine(_picturesProvider.TryLoadTextures(ImagesToLoadOnStart, LoadGallery, 
            _progressBar.UpdateProgress));
    }

    private void LoadGallery(List<Texture> startTextures)
    {
        GalleryData galleryData = new GalleryData()
        {
            StartTextures = startTextures
        };
        GalleryScene.Load(galleryData);
    }
}
