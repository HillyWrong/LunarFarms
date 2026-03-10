using UnityEngine;

public class Player : MonoBehaviour
{
   public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(24);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                GameManager.instance.tileManager.SetInteracted(position);
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

}
