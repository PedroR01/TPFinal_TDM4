using UnityEngine;

public class Collectable_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;

    private void Update()
    {
        this.transform.position -= new Vector3(speed, 0, 0);
    }
}