using UnityEngine;

public class Collectable_Generator2 : MonoBehaviour
{
    [SerializeField] private GameObject petalPrefab; // The sun energy sprite prefab
    [SerializeField] private GameObject birdPrefab; // The cloud sprite prefab

    [SerializeField] private float spawnRate = 2f; // The rate at which sprites spawn
    [SerializeField] private float minSpawnY = -2.5f; // Minimum X position for spawning
    [SerializeField] private float maxSpawnY = 2.5f; // Maximum X position for spawning

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnSprite();
            nextSpawnTime = Time.time + 2f / spawnRate;
        }
    }

    private void SpawnSprite()
    {
        float randomY = Random.Range(minSpawnY, maxSpawnY);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);

        // Randomly choose to spawn a sun or a cloud
        GameObject spritePrefab = Random.value < 0.7f ? petalPrefab : birdPrefab;

        GameObject sprite = Instantiate(spritePrefab, spawnPosition, spritePrefab.transform.rotation);
        sprite.transform.SetParent(transform);

        // Destroy Sprite if it was not collected
        if (sprite != null)
            Destroy(sprite, 8f);
    }
}