using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    private int currentLvl;
    private int index = 0;

    private void Start()
    {
        currentLvl = GameManager.Instance.GetLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.tag == "Positive")
        {
            UIManager.Instance.SetScore(1);
            if (currentLvl == 2)
            {
                transform.GetChild(index).GetComponent<Image>().enabled = true;
                index++;
            }
        }
        else if (collision.tag == "Negative" && UIManager.Instance.GetScore() > 0)
        {
            UIManager.Instance.SetScore(-1);
            if (currentLvl == 2)
            {
                index--;
                transform.GetChild(index).GetComponent<Image>().enabled = false;
            }
        }

        UIManager.Instance.Updating();
    }
}