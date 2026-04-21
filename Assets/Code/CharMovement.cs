using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioManager audioManager;
    public float speed;

public Animator animator;
 private SpriteRenderer spriteRenderer;

 private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //A and D movement, side to side
        float vertical = Input.GetAxisRaw("Vertical"); //W and S movement, up and down

        Vector3 direction = new Vector3(horizontal, vertical);

        //next take current position and multiply by speed and time 
       
        AnimateMovement(direction);
        
        //audioManager.PlaySFX(audioManager.WalkingSFX);

        transform.position += direction * speed * Time.deltaTime;
    
    }

    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0) //magnitude will always be pos cause it lenght
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);


            }
        }
    }

    private void playWalking()
    {
        if(animator.GetBool("isMoving" )== true)
        {
            audioManager.PlaySFX(audioManager.WalkingSFX);
        }
    }

}

