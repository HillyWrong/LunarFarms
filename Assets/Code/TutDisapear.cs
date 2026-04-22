using UnityEngine;
using DG.Tweening;

public class FadeExample : MonoBehaviour
{
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.DOFade(0,20f);
    }

    
}