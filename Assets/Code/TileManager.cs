using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
        [SerializeField] public Tilemap interactableMap ;
        [SerializeField] private Tile hiddenInteractableTile;
        [SerializeField] private Tile plowedTile;
        [SerializeField] private Tile wateredTile;
        [SerializeField] private Tile plantedTile;
        [SerializeField] private Tile[] GrowProgressSprites;


        
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
        interactableMap.SetTile(position, plantedTile);
    }

    public void growing(Vector3Int position) //I know this function is so ineffecient i just wanted to have something working tho..
    {
        DayNightCycle dayNightCycle = GetComponent<DayNightCycle>();
        int CurrentDay = dayNightCycle.days;

       for(int i = 0; i <= CurrentDay; i++)
        {
            interactableMap.SetTile(position, GrowProgressSprites[i]);
        }
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
    