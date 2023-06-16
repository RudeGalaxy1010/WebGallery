using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebTexturesProvider
{
    private const string FileExtension = "jpg";
    private const int FirstTextureOrderNumber = 1;

    private string _folderUrl;
    private AsyncOperation _sendRequestOperation;

    public WebTexturesProvider(string folderUrl)
    {
        _folderUrl = folderUrl;
    }

    public IEnumerator TryLoadTexture(int textureOrderNumber, Action<Texture> onComplete, Action<float> progressChanged)
    {
        Texture result = null;
        string textureUrl = GetTextureUrl(textureOrderNumber);
        using UnityWebRequest request = UnityWebRequestTexture.GetTexture(textureUrl);
        _sendRequestOperation = request.SendWebRequest();

        while (!_sendRequestOperation.isDone)
        {
            progressChanged?.Invoke(_sendRequestOperation.progress / 0.9f);
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            result = DownloadHandlerTexture.GetContent(request);
        }

        onComplete?.Invoke(result);
    }

    public IEnumerator TryLoadTextures(int count, 
        Action<List<Texture>> onComplete, Action<float> progressChanged = null, int firstTextureOrderNumber = FirstTextureOrderNumber)
    {
        List<Texture> result = new List<Texture>();
        float progress = 0;

        for (int i = firstTextureOrderNumber; i < firstTextureOrderNumber + count; i++)
        {
            string textureUrl = GetTextureUrl(i);
            using UnityWebRequest request = UnityWebRequestTexture.GetTexture(textureUrl);
            _sendRequestOperation = request.SendWebRequest();

            while (!_sendRequestOperation.isDone)
            {
                progressChanged?.Invoke(progress + _sendRequestOperation.progress / 0.9f / count);
                yield return null;
            }

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture texture = DownloadHandlerTexture.GetContent(request);
                result.Add(texture);
            }
            else
            {
                result.Add(null);
            }

            progress += _sendRequestOperation.progress / 0.9f / count;
        }

        onComplete?.Invoke(result);
    }

    private string GetTextureUrl(int orderNumber)
    {
        return $"{_folderUrl}/{orderNumber}.{FileExtension}";
    }
}
