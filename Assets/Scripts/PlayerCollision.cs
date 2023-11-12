using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class PlayerCollision : MonoBehaviour
{
    private int currentLvl;
    private int index = 0;
    public Light2D luz;

    private void Start()
    {
        currentLvl = GameManager.Instance.GetLevel();
        //luz.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);


        if (collision.tag == "Positive")
        {
            if (currentLvl == 1) luz.enabled = false;
            UIManager.Instance.SetScore(1);

            if (currentLvl == 2)
            {
                transform.GetChild(index).GetComponent<Image>().enabled = true;
                index++;
            }
        }
        else if (collision.tag == "Negative" && UIManager.Instance.GetScore() > 0)
        {
            if (currentLvl == 1) luz.enabled = true;
            UIManager.Instance.SetScore(-1);

            if (currentLvl == 2 && index > 0)
            {
                index--;
                transform.GetChild(index).GetComponent<Image>().enabled = false;
            }
        }

        UIManager.Instance.Updating();
    }
}