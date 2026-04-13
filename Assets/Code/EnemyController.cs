using Unity.VisualScripting;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject crop;
    public Transform Target; // Reference to the player's transform
    public Collider2D detectionRange;// Range within which the enemy will detect the target
    private Transform enemyTransform;
    private bool isFollowing = false;
    

    private void Start()
    {

        enemyTransform = transform;
    }

    private void Update()
    {
        // Check the distance between enemy and player
        float distanceToTarget = Vector2.Distance(enemyTransform.position, Target.position);

        
        if ()
        {
            isFollowing = true;
            if (gameObject.CompareTag("crop"))
                {
                    MoveTowardsTarget();
                }
        }
        else
        {
            isFollowing = false;
        }
    }

    private void MoveTowardsTarget()
    {
        
        {
            if (isFollowing)
            {
                Vector2 direction = (Target.position - enemyTransform.position).normalized;
                enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, Target.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("crop"))
        {
            MoveTowardsTarget();
        }
    }

 
}
