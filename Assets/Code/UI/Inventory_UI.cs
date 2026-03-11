using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;


public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slots_UI> slots = new List<Slots_UI>();

    [SerializeField] private Canvas canvas;

    private Slots_UI draggedSlot;
    private Image draggedIcon;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();

    }

void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          ToggleInventory();  
        }
    }

    public void ToggleInventory()
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

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
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
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[draggedSlot.slotID].itemName);
        Debug.Log(itemToDrop);
        
        if(itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(draggedSlot.slotID, player.inventory.slots[draggedSlot.slotID].count);
            Refresh();
        }

        draggedSlot = null;
        
    }

    public void SlotBeginDrag(Slots_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(1, 1);

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
        Debug.Log("Dropped : " + draggedSlot.name + "on : " + slot.name);
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
}
