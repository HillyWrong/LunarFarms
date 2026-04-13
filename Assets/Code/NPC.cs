using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public NPCDialouge dialougeData;
    public GameObject dialougePanel;
    public TMP_Text dialougeText, nameText;
    public Image portraitImage;

    private int dialougeIndex;
    private bool isTyping, isDialougeActive;
}