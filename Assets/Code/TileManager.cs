using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
        [SerializeField] private Tilemap interactableMap ;

        [SerializeField] private Tile hiddenInteractableTile;
<<<<<<< HEAD
        [SerializeField] private Tile InteractedTile;
=======
        [SerializeField] private Tile plowedTile;
>>>>>>> parent of db7d505 (tried to add planting and failed)
        void Start()
    {
        foreach(var position in interactableMap .cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null &&  tile.name == "hiddenInteractableTile")
            {
                
            }
           interactableMap.SetTile(position, hiddenInteractableTile);

        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }

            

        }
        
        return false;
    }
    public void SetInteracted(Vector3Int position)
    {
    
<<<<<<< HEAD
        interactableMap.SetTile(position, InteractedTile);
=======
        interactableMap.SetTile(position, plowedTile);
>>>>>>> parent of db7d505 (tried to add planting and failed)
    }

<<<<<<< HEAD
    public void SetWatered(Vector3Int position)
    {
    
        interactableMap.SetTile(position, plowedTileWatered);
    }


    public string GetTileName(Vector3Int position)
    {
        if (interactableMap != null)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null)
            {
                return tile.name;
            }
        }

        return "";
    }

<<<<<<< HEAD
<<<<<<< HEAD
    public void Till()
    {
       tilled = true;
    }

    void OnNewDay()
    {
        if(currentCrop == null)
        {
            //tilled = false;
            //sr.sprite = grassSprite;

            GameManager.instance.onNewDay -= OnNewDay;
        }
        else if(currentCrop != null)
        {
            //sr.sprite = tilledSprite;
            currentCrop.NewDayCheck();
        }
    }
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)

=======
>>>>>>> parent of 3c09a54 (Completed Plowing Mechanic)
}
