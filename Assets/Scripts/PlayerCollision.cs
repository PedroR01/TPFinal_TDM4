using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.tag == "Sun")
            UIManager.Instance.SetScore(1);
        else if (collision.tag == "Cloud" && UIManager.Instance.GetScore() > 0)
            UIManager.Instance.SetScore(-1);

        UIManager.Instance.Updating();
    }
}