using IJunior.TypedScenes;

public class BackGalleryLoader : IInitable, IDeinitable
{
    private PreviewData _previewData;
    private BackGalleryLoaderEmitter _emitter;

    public BackGalleryLoader(PreviewData previewData, BackGalleryLoaderEmitter emitter)
    {
        _previewData = previewData;
        _emitter = emitter;
    }

    public void Init()
    {
        _emitter.BackButton.onClick.AddListener(OnBackButtonClicked);
        _emitter.BackButtonReader.OnBackButtonClicked += OnBackButtonClicked;
    }

    public void Deinit()
    {
        _emitter.BackButton.onClick.RemoveListener(OnBackButtonClicked);
        _emitter.BackButtonReader.OnBackButtonClicked -= OnBackButtonClicked;
    }

    private void OnBackButtonClicked()
    {
        GalleryData galleryData = new GalleryData()
        {
            StartTextures = _previewData.LoadedTextures
        };
        GalleryScene.Load(galleryData);
    }
}
