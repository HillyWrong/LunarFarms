using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData itemData;
    public CropData cropdata;

   [HideInInspector] public Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
