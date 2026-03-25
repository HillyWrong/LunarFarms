
using UnityEngine;
using UnityEngine.Events;

public class Crop : MonoBehaviour
{
    public CropData currentCrop;
    private int plantDay;
    private int daysSinceLastWatered;
    
    

    SpriteRenderer sr;

    public static event UnityAction<CropData>onPlantCrop;
    public static event UnityAction<CropData>onHarvestCrop;

    public void Plant(CropData crop)
    {
        currentCrop = crop;
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

        if(cropProgress < currentCrop.daysToGrow)
        {
            sr.sprite = currentCrop.GrowProgressSprites[cropProgress];
        }
        else
        {
            sr.sprite = currentCrop.readyToHarvestSprite;
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
                onHarvestCrop?.Invoke(currentCrop);
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
        return CropProgress() >= currentCrop.daysToGrow;
    }
}
