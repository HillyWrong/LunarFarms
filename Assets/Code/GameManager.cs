using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ItemManager itemManager;
    public TileManager tileManager;
    public UI_Manager uiManager;
    public int currentDay;
    public int money;

    public Player player;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        uiManager = GetComponent<UI_Manager>();

        player = FindObjectOfType<Player>();
    }

    void OnEnable()
    {
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }

    void OnDisable()
    {
        Crop.onPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;
    }


    public void OnPlantCrop (CropData crop)
    {
        //delete one seed from inventory 
    }

    public void OnHarvestCrop(CropData crop)
    {
        money += crop.sellPrice;
    }
}
