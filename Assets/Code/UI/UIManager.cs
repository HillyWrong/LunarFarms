using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();
  
    public GameObject inventoryPanel;   
    public List<Inventory_UI> inventoryUIs;


   public static Slots_UI draggedSlot;
   public static Image draggedIcon;
   public static bool dragSingle;


private void Awake()
    {
        Initialize();
    }
    
    public void ToggleInventoryUI()
    {
        if (inventoryPanel != null)
        {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            RefreshInventoryUI("Backpack");
        
        }
        else
        {
          inventoryPanel.SetActive(false);
        }
    }
        }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryUI();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true; 
        }
        else
        {
            dragSingle = false;
        }
    
    }

    public void RefreshInventoryUI(string InventoryName)
    {
        if (inventoryUIByName.ContainsKey(InventoryName))
        {
            inventoryUIByName[InventoryName].Refresh();
        }
    }

    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inventory_UI> KeyValuePair in inventoryUIByName)
        {
            KeyValuePair.Value.Refresh();
        }
    }

   public Inventory_UI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }

        Debug.LogWarning("There is not inventory ui for " + inventoryName);
        return null;
    }

    void Initialize()
    {
        foreach(Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }

}
