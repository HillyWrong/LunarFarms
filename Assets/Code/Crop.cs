
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    public CropData cropData;
    private int plantDay;
    private int daysSinceLastWatered;
    
    

    SpriteRenderer sr;

    public static event UnityAction<CropData>onPlantCrop;
    public static event UnityAction<CropData>onHarvestCrop;

    public void Plant(CropData crop)
    {
        cropData = crop;
        plantDay = GameManager.instance.currentDay;
        daysSinceLastWatered = 1;
        updateCropSprite();

        onPlantCrop?.Invoke(crop);
    }

    public void NewDayCheck()
    {
        daysSinceLastWatered++;

        if(daysSinceLastWatered > 3)
        {
            Destroy(gameObject);
        }

        updateCropSprite();
    }

    void updateCropSprite()
    {
        int cropProgress = CropProgress();

        if(cropProgress < cropData.daysToGrow)
        {
            sr.sprite = cropData.GrowProgressSprites[cropProgress];
        }
        else
        {
            sr.sprite = cropData.readyToHarvestSprite;
        }
    }

    public void Water()
    {
        daysSinceLastWatered = 0;
    }

    public void Harvest()
    {
        if (CanHarvest())
        {
            if(CanHarvest())
            {
                onHarvestCrop?.Invoke(cropData);
                Destroy(gameObject);
            }        
        }
    }

    int CropProgress()
    {
       return GameManager.instance.currentDay - plantDay; 
    }

    public bool CanHarvest()
    {
        return CropProgress() >= cropData.daysToGrow;
    }
}
