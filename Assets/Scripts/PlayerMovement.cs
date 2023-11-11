using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Adjust the speed in the Inspector
    [SerializeField] private bool useGyro = true;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private int currentLvl;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true; // Enable the gyroscope
        currentLvl = GameManager.Instance.GetLevel();
    }

    private void FixedUpdate()
    {
        /* - - - PHONE INPUTS FOR MOVEMENT - - - */
        // Get the phone's accelerometer input
        float moveXp = Input.acceleration.x;
        float moveYp = Input.acceleration.y;

        /* - - - ANIMATIONS - - - */
        if (currentLvl == 1)
        {
            if (moveXp > 0)
            {
                animator.SetBool("der", true);
                animator.SetBool("izq", false);
            }
            else if (moveXp < 0)
            {
                animator.SetBool("der", false);
                animator.SetBool("izq", true);
            }
            else
            {
                animator.SetBool("der", false);
                animator.SetBool("izq", false);
            }
            // Calculate the movement vector
            Vector3 moveDirectionP = new Vector3(moveXp, 0, 0);
            if (useGyro)
                moveDirectionP = new Vector3(moveXp, moveYp, 0);

            // Apply the movement
            rb.AddForce(moveDirectionP * moveSpeed);
        }
        else if (currentLvl == 2)
        {
            Vector3 moveDirection = new Vector3(moveXp, moveYp, 0);
            if (useGyro)
                moveDirection = new Vector3(moveXp, moveYp, 0); 
            rb.AddForce(moveDirection * moveSpeed);
        }

    }
}