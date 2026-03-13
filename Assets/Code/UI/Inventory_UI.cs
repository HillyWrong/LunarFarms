using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;


public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public string inventoryName;
    public List<Slots_UI> slots = new List<Slots_UI>();

    private Canvas canvas;

    private bool dragSingle;

    private Inventory inventory;
    private Slots_UI draggedSlot;
    private Image draggedIcon;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();

    }

private void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);
        
        SetupSlots();
        Refresh();
        inventoryPanel.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          ToggleInventory();  
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

    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        
        }
        else
        {
          inventoryPanel.SetActive(false);
        }
    }
        }

    void Refresh()
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
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(inventory.slots[draggedSlot.slotID].itemName);
        Debug.Log(itemToDrop);
        
        if(itemToDrop != null)
        {
            if (dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(draggedSlot.slotID);
            }
            else
            {
            GameManager.instance.player.DropItem(itemToDrop, inventory.slots[draggedSlot.slotID].count);
            inventory.Remove(draggedSlot.slotID, inventory.slots[draggedSlot.slotID].count);
            }

            Refresh();
        }

        draggedSlot = null;
        
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        draggedSlot = slot;

        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(29f, 19.5f);
        draggedIcon.transform.SetParent(canvas.transform);

        MoveToMousePosition(draggedIcon.gameObject);

        Debug.Log("Start Drag: " + draggedSlot.name);
    }

    public void SlotDrag()
    {
        Debug.Log("Dragging: " + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;
        Debug.Log("Done Dragging: " + draggedSlot.name);
    }

    public void SlotDrop(Slots_UI slot)
    {
        draggedSlot.inventory.MoveSlot(draggedSlot.slotID, slot.slotID);
        Refresh();
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
