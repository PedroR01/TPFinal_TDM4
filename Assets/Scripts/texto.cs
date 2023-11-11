using UnityEngine;
using TMPro;

public class texto : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI finalScoreText;  

     private void Update()
    {
        finalScoreText.text = GameManager.Instance.GetScore(0).ToString() + "\n" + GameManager.Instance.GetScore(1).ToString() + "\n" + GameManager.Instance.GetScore(2).ToString();
    }        

}