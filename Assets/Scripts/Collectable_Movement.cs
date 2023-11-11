using UnityEngine;

public class Collectable_Movement : MonoBehaviour
{
    private void Update()
    {
        this.transform.position -= new Vector3(.03f, 0, 0);
    }
}