using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CropManager : MonoBehaviour
{
    
    public Crop[] crops;

    private Dictionary<string, Crop> nameToCropDict = new Dictionary<string, Crop>();

    private void Awake()
    {
        foreach(Crop crop in crops)
        {
            AddCrop(crop);
        
        }    
    }

    private void AddCrop(Crop crop)
    {
        if (!nameToCropDict.ContainsKey(crop.cropData.cropName))
        {
            nameToCropDict.Add(crop.cropData.cropName, crop);

        }

    }

    public Crop GetCropByName(string key)
    {
        if (nameToCropDict.ContainsKey(key))
        {
            return nameToCropDict[key];

        }

        return null;

    }
}
