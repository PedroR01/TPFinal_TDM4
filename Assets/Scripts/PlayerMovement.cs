using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed in the Inspector
    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true; // Enable the gyroscope
    }

    private void FixedUpdate()
    {
        // Get input from the player
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Apply the movement
        rb.velocity = moveDirection * moveSpeed;

        /* - - - PHONE INPUTS FOR MOVEMENT - - - */
        // Get the phone's accelerometer input
        float moveXp = Input.acceleration.x;
        float moveYp = Input.gyro.userAcceleration.z;

        // Calculate the movement vector
        Vector3 moveDirectionP = new Vector3(moveXp, moveYp, 0).normalized;

        // Get the phone's gyroscope rotation
        Quaternion gyroRotation = Input.gyro.attitude;
        gyroRotation = new Quaternion(gyroRotation.x, gyroRotation.y, -gyroRotation.z, -gyroRotation.w);

        // Calculate the movement vector based on pitch (forward and backward tilt)
        float pitch = gyroRotation.eulerAngles.x;

        // Apply the vertical movement
        Vector3 moveDirection2 = new Vector3(0, pitch, 0).normalized;
        //rb.AddForce(moveDirection2 * moveSpeed);

        // Apply the movement
        rb.AddForce(moveDirectionP * moveSpeed);
    }
}