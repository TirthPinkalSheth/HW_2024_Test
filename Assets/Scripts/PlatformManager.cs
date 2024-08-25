using System.Collections;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject pulpitPrefab;   // Platform prefab
    public Transform doofus;          // Reference to Doofus

    private GameObject currentPulpit; // To keep track of the currently active pulpit

    void Start()
    {
        // Step 1: Spawn the first pulpit at a fixed position
        SpawnFirstPulpit();

        // Step 2: Start spawning new pulpits when the previous one is about to be destroyed
        StartCoroutine(SpawnPulpits());
    }

    // Function to spawn the first pulpit at a fixed position
    void SpawnFirstPulpit()
    {
        // Fixed spawn position for the first pulpit
        Vector3 spawnPos = new Vector3(0, 0, 0); // Adjust this position if needed

        // Instantiate the first pulpit at a fixed position
        currentPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity);

        // Random lifetime for the first pulpit
        float destroyTime = UnityEngine.Random.Range(ConfigManager.doofusDiary.pulpit_data.min_pulpit_destroy_time,
                                                     ConfigManager.doofusDiary.pulpit_data.max_pulpit_destroy_time);

        // Destroy the first pulpit after a random time
        Destroy(currentPulpit, destroyTime);
    }

    // Coroutine to spawn new pulpits after the first one is destroyed
    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            // Wait until the current pulpit is destroyed
            yield return new WaitUntil(() => currentPulpit == null);

            // Spawn subsequent pulpits around Doofus
            Vector3 spawnPos = new Vector3(doofus.position.x + UnityEngine.Random.Range(-10, 10),
                                           0,
                                           doofus.position.z + UnityEngine.Random.Range(-10, 10));

            // Instantiate a new pulpit at a random position near Doofus
            currentPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity);

            // Random lifetime for the new pulpit
            float destroyTime = UnityEngine.Random.Range(ConfigManager.doofusDiary.pulpit_data.min_pulpit_destroy_time,
                                                         ConfigManager.doofusDiary.pulpit_data.max_pulpit_destroy_time);

            // Destroy the pulpit after the random time
            Destroy(currentPulpit, destroyTime);

            // Wait for the next pulpit to spawn after the specified spawn time from the JSON
            yield return new WaitForSeconds(ConfigManager.doofusDiary.pulpit_data.pulpit_spawn_time);
        }
    }
}
