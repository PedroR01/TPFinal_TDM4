using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.tag == "Sun")
            UIManager.Instance.score++;
        else if (collision.tag == "Cloud" && UIManager.Instance.score > 0)
            UIManager.Instance.score--;

        UIManager.Instance.Updating();
    }
}