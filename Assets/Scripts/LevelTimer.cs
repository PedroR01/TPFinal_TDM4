using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && UIManager.Instance.GetScore() <= 0)
            GameManager.Instance.Loose();
        else if (timer <= 0 || UIManager.Instance.GetScore() >= 10)
            GameManager.Instance.NextLevel();
    }
}