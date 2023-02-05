using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MosaicData {
    public int xDimension, yDimension;
    public int noOfTiles;

    public static MosaicData Create(int widthRatio, int heightRatio, int multiplicativeFactor) {
        MosaicData data = new();
        data.xDimension = widthRatio * multiplicativeFactor;
        data.yDimension = heightRatio * multiplicativeFactor;
        data.noOfTiles = widthRatio * heightRatio * multiplicativeFactor;

        return data;
    }
}
