using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private int scoreLvlToPrint;

    private void Start()
    {
        finalScoreText.text = GameManager.Instance.GetScore(scoreLvlToPrint - 1).ToString();
    }
}