using System.Collections;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public Transform doofus;

    private GameObject currentPulpit;

    void Start()
    {
        StartCoroutine(SpawnPulpit());
    }

    IEnumerator SpawnPulpit()
    {
        while (true)
        {
            if (currentPulpit == null)
            {
                Vector3 spawnPos = new Vector3(doofus.position.x + Random.Range(-10, 10), 0, doofus.position.z + Random.Range(-10, 10));
                currentPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity);

                // Use the min and max pulpit destroy times from JSON
                float duration = Random.Range(ConfigManager.doofusDiary.pulpit_data.min_pulpit_destroy_time,
                                              ConfigManager.doofusDiary.pulpit_data.max_pulpit_destroy_time);
                Destroy(currentPulpit, duration);
            }

            // Wait for pulpit_spawn_time before spawning the next pulpit
            yield return new WaitForSeconds(ConfigManager.doofusDiary.pulpit_data.pulpit_spawn_time);
        }
    }
}
