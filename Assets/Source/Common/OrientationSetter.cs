using UnityEngine;
using UnityEngine.SceneManagement;

public class OrientationSetter
{
    private const int AutoRotationOrientationSceneIndex = 2;

    public OrientationSetter()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == AutoRotationOrientationSceneIndex)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
