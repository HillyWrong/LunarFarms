using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ItemManager itemManager;
    public TileManager tileManager;
    public UI_Manager uiManager;

    public Player player;

    public int currentDay;
    public int money;
    public int cropInventory;
    public CropData selectedCropToPlant;
    public bool HasCrop;

    public event UnityAction onNewDay;


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
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }

    public void OnPlantCrop (CropData crop)
    {
        cropInventory--;
    }

    public void OnHarvestCrop (CropData crop)
    {
        money += crop.sellPrice;
    }

    public void PurchaseCrop (CropData crop)
    {
        
    }

    public void OnNewDay()
    {
        
    }

    public void CanPlantCrop()
    {
        if(HasCrop == true)
        {
        
        }
    }
    
    public void OnBuyCropButton(CropData crop)
    {
        
    }
   


}
