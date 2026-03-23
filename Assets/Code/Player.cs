
using System.Net;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;

    public GameManager gameManager;

    private bool isPlowed;


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
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                GameManager.instance.tileManager.SetInteracted(position);
                isPlowed = true;
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



   
