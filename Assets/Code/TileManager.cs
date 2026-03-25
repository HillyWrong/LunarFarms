using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
        [SerializeField] private Tilemap interactableMap ;
        [SerializeField] private Tile hiddenInteractableTile;
        [SerializeField] private Tile plowedTile;
        [SerializeField] private Tile wateredTile;


        
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
    
        interactableMap.SetTile(position, wateredTile);
    }

    public void SetPlanted(Vector3Int position)
    {
    
        interactableMap.SetTile(position, wateredTile);
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
}
    