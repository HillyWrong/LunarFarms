using System.Net;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    public InventoryManager inventoryManager;
    private TileManager tileManager;
    private Crop currentCrop;
    public GameObject cropPrefab;
    public GameManager gameManager;
    public TileManager tilled;


    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }
    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "Interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                    }
                }
               

            }

        void PlantNewCrop(CropData crop)
        {
            if (!tilled)
            {
                return;
            }

            currentCrop = Instantiate(cropPrefab, transform).GetComponent<Crop>();
            currentCrop.Plant(crop);

            GameManager.instance.onNewDay += gameManager.OnNewDay;
        }
    
        }
    }

    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset  = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        SpriteRenderer sr = droppedItem.GetComponent<SpriteRenderer>();
        //sr.sprite = item.icon;
        sr.sortingOrder = 7;

        droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }

   // private bool HasCrop()
   // {
       // return true;
   

    public void DropItem(Item item, int numToDrop)
    {
       for(int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}
