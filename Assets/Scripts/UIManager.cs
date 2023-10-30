using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    // UI data and variables
    private int score = 0;

    [SerializeField] private Slider energySlider;
    [SerializeField] private Image energyFace;
    [SerializeField] private Sprite[] facesLvl1;
    [SerializeField] private Sprite[] facesLvl2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the UI manager between scenes
        }
        else
            Destroy(gameObject); // Destroy any additional instances
    }

    // Add methods to update and retrieve UI data as needed

    public void Updating()
    {
        energySlider.value = score;
        if (GameManager.Instance.GetLevel() == 1)
        {
            if (score >= 8)
                energyFace.sprite = facesLvl1[3];
            else if (score >= 5)
                energyFace.sprite = facesLvl1[2];
            else if (score >= 2)
                energyFace.sprite = facesLvl1[1];
            else
                energyFace.sprite = facesLvl1[0];
        }
        else if (GameManager.Instance.GetLevel() == 2)
        {
            if (score >= 9)
                energyFace.sprite = facesLvl2[4];
            else if (score >= 6)
                energyFace.sprite = facesLvl2[3];
            else if (score >= 4)
                energyFace.sprite = facesLvl2[2];
            else if (score >= 2)
                energyFace.sprite = facesLvl2[1];
            else
                energyFace.sprite = facesLvl2[0];
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int _score)
    {
        score += _score;
    }
}