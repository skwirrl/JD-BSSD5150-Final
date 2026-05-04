using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] partPrefabs;   // good items
    [SerializeField] private GameObject[] junkPrefabs;   // bad items
    [SerializeField] private Transform[] spawnPoints;    // drop locations along the top

    // time between spawns in seconds — decreases as game progresses
    [SerializeField] private float spawnInterval = 2f;
    private float timer = 0f;

    void Update()
    {
        // simple timer, count up each frame, spawn when interval is reached
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        // pick a random position from the spawn points array
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spot = spawnPoints[spawnIndex];

        // 70% chance of a useful part, 30% chance of junk
        GameObject prefab;
        if (Random.Range(0f, 1f) < 0.7f)
            prefab = partPrefabs[Random.Range(0, partPrefabs.Length)];
        else
            prefab = junkPrefabs[Random.Range(0, junkPrefabs.Length)];

        // create the item — it falls automatically because its gravity scale is 1
        Instantiate(prefab, spot.position, Quaternion.identity);
    }

    // called by GameController to increase difficulty
    public void SetSpawnRate(float interval)
    {
        spawnInterval = interval;
    }
}