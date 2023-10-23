using System.Collections;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject sunPrefab; // The sun energy sprite prefab
    public GameObject cloudPrefab; // The cloud sprite prefab

    public float spawnRate = 2f; // The rate at which sprites spawn
    public float minSpawnX = -2.5f; // Minimum X position for spawning
    public float maxSpawnX = 2.5f; // Maximum X position for spawning

    private float nextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnSprite();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnSprite()
    {
        float randomX = Random.Range(minSpawnX, maxSpawnX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        // Randomly choose to spawn a sun or a cloud
        GameObject spritePrefab = Random.value < 0.5f ? sunPrefab : cloudPrefab;

        GameObject sprite = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);

        // Destroy Sprite if it was not collected
        if (sprite != null)
            Destroy(sprite, 5f);
    }
}