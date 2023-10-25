using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

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
    public void Loose()
    {
        // When you loose, load the roadmap scene again. (TO FIX: keep the score that you have before the loosing attempt and loose 1 life).
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        // Loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}