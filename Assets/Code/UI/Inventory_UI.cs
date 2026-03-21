using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using static Inventory_UI;



public class Inventory_UI : MonoBehaviour
{
    
    public string inventoryName;
    public List<Slots_UI> slots = new List<Slots_UI>();

    private Canvas canvas;

    private bool dragSingle;

    private Inventory inventory;


    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();

    }

private void Start()
    {
        inventory = GameManager.instance.player.inventoryManager.GetInventoryByName(inventoryName);
        
        SetupSlots();
        Refresh();
        

    }

    public void Refresh()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }

        }
      
        
    }

    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(inventory.slots[UI_Manager.draggedSlot.slotID].itemName);
        Debug.Log(itemToDrop);
        
        if(itemToDrop != null)
        {
            if (UI_Manager.dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(UI_Manager.draggedSlot.slotID);
            }
            else
            {
            GameManager.instance.player.DropItem(itemToDrop, inventory.slots[UI_Manager.draggedSlot.slotID].count);
            inventory.Remove(UI_Manager.draggedSlot.slotID, inventory.slots[UI_Manager.draggedSlot.slotID].count);
            }

            Refresh();
        }

        UI_Manager.draggedSlot = null;
        
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        UI_Manager.draggedSlot = slot;

        UI_Manager.draggedIcon = Instantiate(UI_Manager.draggedSlot.itemIcon);
        UI_Manager.draggedIcon.raycastTarget = false;
        UI_Manager.draggedIcon.rectTransform.sizeDelta = new Vector2(29f, 19.5f);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform);

        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);

        Debug.Log("Start Drag: " + UI_Manager.draggedSlot.name);
    }

    public void SlotDrag()
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;
      
    }

    public void SlotDrop(Slots_UI slot)
    {
        if(UI_Manager.dragSingle)
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID,slot.slotID, slot.inventory);
        }
        else
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID,slot.slotID, slot.inventory, UI_Manager.draggedSlot.inventory.slots[UI_Manager.draggedSlot.slotID].count);
        }

        GameManager.instance.uiManager.RefreshAll();
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position);
        }

    }

    void SetupSlots()
    {
        int counter = 0;

        foreach(Slots_UI slot in slots)
        {
            slot.slotID = counter; 
            counter++;
            slot.inventory = inventory;
        }
    }
}
