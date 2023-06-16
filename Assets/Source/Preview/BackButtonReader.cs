using System;
using UnityEngine;

public class BackButtonReader : MonoBehaviour
{
    private const KeyCode BackButton = KeyCode.Escape;

    public event Action OnBackButtonClicked;

    private void Update()
    {
        if (Input.GetKeyDown(BackButton))
        {
            OnBackButtonClicked?.Invoke();
        }
    }
}
