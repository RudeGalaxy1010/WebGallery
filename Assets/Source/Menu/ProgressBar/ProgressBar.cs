public class ProgressBar
{
    private ProgressBarEmitter _emitter;

    public ProgressBar(ProgressBarEmitter emitter)
    {
        _emitter = emitter;
    }

    public void SetVisible(bool isVisible)
    {
        _emitter.Background.SetActive(isVisible);
    }

    public void UpdateProgress(float progress)
    {
        _emitter.ProgressImage.fillAmount = progress;
    }
}
