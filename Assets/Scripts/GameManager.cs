using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    private int[] scores;

    private void Awake()
    {
        scores = new int[3];
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep the UI manager between scenes
        }
        else
            Destroy(gameObject); // Destroy any additional instances
    }

    // Add methods to update and retrieve UI data as needed
    public void Loose()
    {
        // When you loose, re-load the level to try again. (TO ADD: loose 1 life).
        UIManager.Instance.SetScore(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        // Store the score of the current level
        scores[SceneManager.GetActiveScene().buildIndex - 2] = UIManager.Instance.GetScore();
        // Re-set the score for the next level
        UIManager.Instance.SetScore(-UIManager.Instance.GetScore());
        // Change UI score bar
        if (SceneManager.GetActiveScene().buildIndex > 1 && SceneManager.GetActiveScene().buildIndex < 5)
            UIManager.Instance.ChangeScoreUI(SceneManager.GetActiveScene().buildIndex - 2);
        // Loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int GetLevel()
    {
        return SceneManager.GetActiveScene().buildIndex - 1; // Substract 1 because of the build index that has main menu and roadmap as lvl 0 and 1.
    }
}