using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Singleton instance
    public static UIManager Instance;

    // UI data and variables
    private int score = 0;

    [SerializeField] private Slider energySlider;

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