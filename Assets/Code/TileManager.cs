using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TileManager : MonoBehaviour
{
        [SerializeField] private Tilemap interactableMap ;

        [SerializeField] private Tile hiddenInteractableTile;
        [SerializeField] private Tile plowedTile;
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
    public void SetInteracted(Vector3Int position)
    {
    
        interactableMap.SetTile(position, plowedTile);
    }

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

}
