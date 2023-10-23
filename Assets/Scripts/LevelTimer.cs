using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            GameManager.Instance.Loose();
    }
}