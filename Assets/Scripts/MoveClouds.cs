using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    private Transform cloudsTransform;
    private float initialXPosition;

    private void Start()
    {
        cloudsTransform = GetComponent<Transform>();
        initialXPosition = cloudsTransform.position.x;
    }

    private void Update()
    {
        float offsetX = Time.time * scrollSpeed;
        float newXPosition = initialXPosition - offsetX;
        cloudsTransform.position = new Vector3(newXPosition, cloudsTransform.position.y, cloudsTransform.position.z);
    }
}