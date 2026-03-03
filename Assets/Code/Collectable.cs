using UnityEngine;

public class Collectable : MonoBehaviour
{
    //player walks into collectable 
    //add collectable to player
    //delete collectable from scene

    public CollectableType type;
    public Sprite icon;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }

   
}
 public enum CollectableType  //enum is a set of named constants that have an underlying numeric type, default associated constant is an interger.
    {
        NONE, CARROT_SEED
    }