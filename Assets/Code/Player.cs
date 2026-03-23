<<<<<<< HEAD
=======
using System.Net;
>>>>>>> parent of db7d505 (tried to add planting and failed)
using UnityEngine;

public class Player : MonoBehaviour
{

<<<<<<< HEAD
    public InventoryManager inventoryManager;
    private TileManager tileManager;
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of db7d505 (tried to add planting and failed)

    public GameManager gameManager;


=======
>>>>>>> parent of db7d505 (tried to add planting and failed)

    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }
=======
    public InventoryManager inventory;
>>>>>>> parent of 3c09a54 (Completed Plowing Mechanic)
    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    private void Update()
<<<<<<< HEAD
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                GameManager.instance.tileManager.SetInteracted(position);
            }
<<<<<<< HEAD
<<<<<<< HEAD

       
=======

        }
>>>>>>> parent of 3c09a54 (Completed Plowing Mechanic)
    }
}

private void Water()
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "DryPLowed" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                    }
                }

            }
<<<<<<< HEAD

       
    } 
=======
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
        }
>>>>>>> parent of db7d505 (tried to add planting and failed)
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

    public void DropItem(Item item, int numToDrop)
    {
       for(int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}
