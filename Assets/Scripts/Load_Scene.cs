using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad; // Name of the scene to load

    // This method is called when the button is clicked.
    public void LoadSceneOnClick()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
            UIManager.Instance.ChangeScoreUI(0);

       // Load the scene by name
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}