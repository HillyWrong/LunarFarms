using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //A and D movement, side to side
        float vertical = Input.GetAxisRaw("Vertical"); //W and S movement, up and down

        Vector3 direction = new Vector3(horizontal, vertical);

        //next take current position and multiply by speed and time 

        transform.position += direction * speed * Time.deltaTime;

    }
}