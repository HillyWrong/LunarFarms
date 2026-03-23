using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ItemManager itemManager;
    public TileManager tileManager;
    public UI_Manager uiManager;

    public Player player;

<<<<<<< HEAD
<<<<<<< HEAD
    public int currentDay;
    public int money;
    

    public event UnityAction onNewDay;


=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        uiManager = GetComponent<UI_Manager>();

        player = FindObjectOfType<Player>();
    }
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
=======
>>>>>>> parent of db7d505 (tried to add planting and failed)
}
