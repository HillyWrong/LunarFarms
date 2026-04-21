using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
   
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    public GameManager gameManager;
    public GameObject cropPrefab;

    private bool isPlowed;
    public bool isPlanted;
    private Crop crop;



    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }

    public InventoryManager inventory;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if(tileName == "Interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                        
                    } 
                    
                    if(tileName == "DryPlowed_0" && inventoryManager.toolbar.selectedSlot.itemName == "WateringCan")
                    {
                        tileManager.SetWatered(position);
                        
            
                    }

                     if(tileName == "WateredTile" && inventoryManager.toolbar.selectedSlot.itemName == "Caroot Seeds")
                    {
                        Instantiate(cropPrefab, transform.position, Quaternion.identity);
                        cropPrefab.SetActive(true);
                        isPlanted = true;
                        if(isPlanted == true)
                        {
                            cropPrefab.tag = "crop";
                        }
                        
                    } 
                }
            }
        }
    }

    

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 1.5f;

        Item DroppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        DroppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);

    } 

   
    
    public void DropItem(Item item, int numToDrop)
    {
       for(int i = 0; i < numToDrop; i++)
       {
            DropItem(item);
        }

    }



}



   
