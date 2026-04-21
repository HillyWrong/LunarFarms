using Unity.VisualScripting;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject crop;
    public Transform Target;
    public Collider2D detectionRange;
    private Transform enemyTransform;
    private bool isFollowing = false;
    

    private void Start()
    {
        enemyTransform = transform;
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
