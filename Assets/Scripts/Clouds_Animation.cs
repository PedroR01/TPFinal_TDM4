using UnityEngine;
using UnityEngine.UIElements;

public class Clouds_Animation : MonoBehaviour
{
    [SerializeField] private Vector2 vel; 
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = vel * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

}