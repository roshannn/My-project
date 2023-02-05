using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class MosaicHelper {

    
    public static MosaicData GetMosaicDimension(int noOfPhotos, int widthRatio, int heightRatio) {
        int multiplicativeFactor = Mathf.FloorToInt(Mathf.Sqrt(noOfPhotos / (widthRatio * heightRatio)));
        return MosaicData.Create(widthRatio, heightRatio,multiplicativeFactor);
    }

    public static TileData GetMosaicTileDimension(float width, float height, MosaicData mosaicData) {
        Debug.Log($"Screen Width : {width},Screen Height : {height}");
        int tileWidth = (int)width / mosaicData.xDimension;
        int tileHeight = (int)height/ mosaicData.yDimension;
        return new(tileWidth, tileHeight);
    }

}
