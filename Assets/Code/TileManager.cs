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

        private int CurrentDay;
        private int PlantDay;
        private int DaysToGrow = 4;

    public void Update()
    {
        DayNightCycle dayNightCycle = GetComponent<DayNightCycle>();
        CurrentDay = dayNightCycle.days;
    }
        
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

   // public Tile growing(TileName,Vector3Int position) //I know this function is so ineffecient i just wanted to have something working tho..
    //{
       // PlantDay = CurrentDay;

      //  while(PlantDay != (CurrentDay + DaysToGrow))
      //  {
           // interactableMap.SetTile(position, GrowProgressSprites[CurrentDay]);
     //   }
   // }
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
    