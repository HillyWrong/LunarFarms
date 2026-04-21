using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slots_UI> toolbarSlots = new List<Slots_UI>();

    private Slots_UI selectedSlot;
    AudioManager audioManager;

    private void Start()
    {
        SelectSlot(0);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


   
    public void SelectSlot(int index)
    {
        if(toolbarSlots.Count == 6)
        {
            if(selectedSlot != null)
            {
                audioManager.PlaySFX(audioManager.collectiblesSFX);
                selectedSlot.SetHighlight(false);
                

            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighlight(true);

            GameManager.instance.player.inventoryManager.toolbar.SelectSlot(index);
        }   
    }

    private void Update()
    {
        CheckAlphaNumericKeys();
    }

    private void CheckAlphaNumericKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
         if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
         if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
         if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
         if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
         if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }
         if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }
    }
}
 