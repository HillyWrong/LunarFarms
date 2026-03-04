using UnityEngine;

public class Player : MonoBehaviour
{
   public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(16);

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

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset  = Random.insideUnitCircle * 5.25f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        SpriteRenderer sr = droppedItem.GetComponent<SpriteRenderer>();
        sr.sprite = item.icon;
        sr.sortingOrder = 7;

        droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }

}
