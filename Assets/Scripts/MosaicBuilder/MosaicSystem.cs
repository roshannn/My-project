using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosaicSystem : MonoBehaviour {
    [SerializeField] private MosaicPool tilePooler;
    [SerializeField] private Image MainImage;
    [SerializeField] private string url;
    [SerializeField] private int xRatio, yRatio;
    [SerializeField]private int noOfPhotos = 4999;
    MosaicData mosaicData;
    private async void Awake() {
        await GetBackground();
        InitializeMosaic();
    }

    private async UniTask GetBackground() {
        Texture2D texture = await ImageFetcher.GetTexture(url);
        MainImage.sprite = ImageFetcher.ConvertTexture2DToSprite(texture);
    }

    private void InitializeMosaic() {
        Vector2 temp = Vector2.zero;
        mosaicData = MosaicHelper.GetMosaicDimension(noOfPhotos, xRatio, yRatio);
        TileData tileData = MosaicHelper.GetMosaicTileDimension(Screen.width, Screen.height, mosaicData);
        for (int i = 0; i < mosaicData.yDimension; i++) {
            for (int j = 0; j < mosaicData.xDimension; j++) {
                var x = tilePooler.GetItemFromPool();
                x.transform.SetParent(MainImage.transform);
                x.name = $"Tile {(i * mosaicData.xDimension) + j + 1}";
                x.rectTransform.sizeDelta = new Vector2(tileData.width, tileData.height);
                x.rectTransform.anchoredPosition = temp;
                temp.x += tileData.width;
            }
            temp.x = 0;
            temp.y -= tileData.height;
        }
    }
}
