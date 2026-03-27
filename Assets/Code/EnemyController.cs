using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform Target; // Reference to the player's transform
    public float detectionRange = 10000f; // Range within which the enemy will detect the target
    private Transform enemyTransform;
    private bool isFollowing = false; // Flag to indicate if the enemy should move

    private void Start()
    {
        enemyTransform = transform;
    }

    private void Update()
    {
        // Check the distance between enemy and player
        float distanceToPlayer = Vector2.Distance(enemyTransform.position, Target.position);

        // If player is within detection range, start moving towards the player
        if (distanceToPlayer <= detectionRange)
        {
            isFollowing = true;
            MoveTowardsPlayer();
        }
        else
        {
            isFollowing = false; // Stop moving if player is out of range
        }
    }

    private void MoveTowardsPlayer()
    {
        if (isFollowing)
        {
            Vector2 direction = (Target.position - enemyTransform.position).normalized;
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, Target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            isFollowing = false; // Stop moving when colliding with the player
        }
    }
}
