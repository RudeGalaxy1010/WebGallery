using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class GalleryLoader : IInitable, IDeinitable
{
    private const int ImagesToLoadOnStart = 10;

    private WebTexturesProvider _picturesProvider;
    private GalleryLoaderEmitter _emitter;

    public GalleryLoader(WebTexturesProvider picturesProvider, GalleryLoaderEmitter emitter)
    {
        _picturesProvider = picturesProvider;
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
        _emitter.StartCoroutine(_picturesProvider.TryLoadTextures(ImagesToLoadOnStart, 
            (textures) => LoadGallery(textures), (progress) => _ = progress));

        // TODO:
        // 1) Load 10 images - DONE!
        // 2) Add progress bar
        // 3) Put images into 'GalleryData' and call SceneLoader.LoadGallery(GalleryData);
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
