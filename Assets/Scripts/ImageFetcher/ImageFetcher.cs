using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class ImageFetcher {
    public static async UniTask<Texture2D> GetTexture(string url) {
        Texture2D texture = null;
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        Debug.Log("///////////////////////////////");
        Debug.Log("Starting Download");
        await uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError) {
            Debug.Log("Couldn't fetch image");
            Debug.Log("Stopping Download");
        } else {
            Debug.Log("Download Complete");
            texture = DownloadHandlerTexture.GetContent(uwr);
        }
        Debug.Log("///////////////////////////////");
        texture.Compress(false);    
        return texture;
    }

    public static Sprite ConvertTexture2DToSprite(Texture2D texture) {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
    }
}
