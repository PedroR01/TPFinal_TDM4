using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    // UI data and variables
    private int score = 0;

    [SerializeField] private GameObject[] scoreUI;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Image energyFace;
    [SerializeField] private Image energyFace2;
    [SerializeField] private Image energyFace3;
    [SerializeField] private Sprite[] facesLvl1;
    [SerializeField] private Sprite[] facesLvl2;
    [SerializeField] private Sprite[] compostLvl3;

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
        if (GameManager.Instance.GetLevel() == 1)
        {
            energySlider.value = score;

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
                energyFace2.sprite = facesLvl2[4];
            else if (score >= 6)
                energyFace2.sprite = facesLvl2[3];
            else if (score >= 4)
                energyFace2.sprite = facesLvl2[2];
            else if (score >= 2)
                energyFace2.sprite = facesLvl2[1];
            else
                energyFace2.sprite = facesLvl2[0];
        }
        else if (GameManager.Instance.GetLevel() == 3)
        {
            switch (score)
            {
                case 0:
                    energyFace3.sprite = compostLvl3[0];
                    break;

                case 1:
                    energyFace3.sprite = compostLvl3[1];
                    break;

                case 2:
                    energyFace3.sprite = compostLvl3[2];
                    break;

                case 3:
                    energyFace3.sprite = compostLvl3[3];
                    break;

                case 4:
                    energyFace3.sprite = compostLvl3[4];
                    break;

                case 5:
                    energyFace3.sprite = compostLvl3[5];
                    break;

                case 6:
                    energyFace3.sprite = compostLvl3[6];
                    break;

                case 7:
                    energyFace3.sprite = compostLvl3[7];
                    break;
            }
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

    public void ChangeScoreUI(int whichUI)
    {
        switch (whichUI)
        {
            case 0:
                scoreUI[0].SetActive(true);
                scoreUI[1].SetActive(false);
                scoreUI[2].SetActive(false);
                break;

            case 1:
                scoreUI[0].SetActive(false);
                scoreUI[1].SetActive(true);
                scoreUI[2].SetActive(false);
                break;

            case 2:
                scoreUI[0].SetActive(false);
                scoreUI[1].SetActive(false);
                scoreUI[2].SetActive(true);
                break;

            case 3:
                scoreUI[0].SetActive(false);
                scoreUI[1].SetActive(false);
                scoreUI[2].SetActive(false);
                break;
        }
    }
}