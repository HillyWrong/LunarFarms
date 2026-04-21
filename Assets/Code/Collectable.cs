using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    //player walks into collectable 
    //add collectable to player
    //delete collectable from scene

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            Item item = GetComponent<Item>();

            if(item != null )
            audioManager.PlaySFX(audioManager.collectiblesSFX);
            {
                player.inventoryManager.Add("Backpack", item);
                Destroy(this.gameObject);
            }

            
        }
    }

   
}
 