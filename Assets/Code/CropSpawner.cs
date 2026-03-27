using UnityEngine;

public class CropSpawner : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Crop[] crops;

    private Crop currentCrop;
    
    [SerializeField]
    private Transform[] spawnPoints; 

    private bool stopSpawning = false;

    private void Awake()
    {
        
    }

}
