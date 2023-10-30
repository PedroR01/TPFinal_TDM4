using UnityEngine;
using UnityEngine.UIElements;

public class Clouds_Animation : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2.0f; // Adjust the scroll speed as needed.
    private Vector3 resetPosition; // The X position at which the clouds will restart.
    [SerializeField] private Transform[] clouds;
    [SerializeField] private Transform playerTransform;
    private int cloudIndex = 0;

    private void Start()
    {
        //
        resetPosition = clouds[1].position;
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        //
        float offset = Time.deltaTime * scrollSpeed;

        clouds[cloudIndex].position -= new Vector3(offset, 0, 0);

        float cloudPositionX = clouds[cloudIndex].position.x;
        if (cloudPositionX <= -4)
        {
            if (cloudIndex == 0)
                clouds[cloudIndex + 1].position -= new Vector3(offset, 0, 0);
            else
                clouds[cloudIndex - 1].position -= new Vector3(offset, 0, 0);
            if (cloudPositionX <= -17)
            {
                clouds[cloudIndex].position = resetPosition;
                cloudIndex = cloudIndex == 1 ? 0 : 1;
            }
        }
    }
}