using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="NewNPCDialouge", menuName = "New NPC Dialouge")]
public class NPCDialouge : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialougeLines; 
    public bool[] autoProgressLines;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
   
    public float autoProgressDelay = 1.5f;

}

  
