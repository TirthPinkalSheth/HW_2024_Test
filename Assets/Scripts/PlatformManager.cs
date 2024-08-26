using System.Collections;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    public GameObject pulpitPrefab;
    public Transform doofus;

    private GameObject currentPulpit;
    public Vector3 currentPulpitPos;
    void Awake(){
        instance=this;
    }
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
        currentPulpitPos = currentPulpit.transform.position;
        // Random lifetime for the first pulpit
        float destroyTime = Random.Range(ConfigManager.doofusDiary.pulpit_data.min_pulpit_destroy_time,
                                                     ConfigManager.doofusDiary.pulpit_data.max_pulpit_destroy_time);

        currentPulpit.GetComponent<TimerUI>().timer=destroyTime;
        // Destroy the first pulpit after a random time
        StartCoroutine(DestroyRoutine(currentPulpit, destroyTime));
    }

    // Coroutine to spawn new pulpits after the first one is destroyed
    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            Debug.Log("Start");
            // Wait until the current pulpit is destroyed
            yield return new WaitForSeconds(ConfigManager.doofusDiary.pulpit_data.pulpit_spawn_time);

            // Spawn subsequent pulpits around Doofus
            Vector3 spawnPos = Vector3.zero;
            float randomXOffset = 0f;
            float randomZOffset = 0f;
            while ((randomXOffset == 0 && randomZOffset == 0) || (randomXOffset != 0 && randomZOffset != 0))
            {
                randomXOffset = Random.Range(-1, 1);
                randomZOffset = Random.Range(-1, 1);
                spawnPos = new Vector3(currentPulpitPos.x + (randomXOffset * 9), 0, currentPulpitPos.z + (randomZOffset * 9));
            }
            // Instantiate a new pulpit at a random position near Doofus
            currentPulpit = Instantiate(pulpitPrefab, spawnPos, Quaternion.identity);
            currentPulpitPos = currentPulpit.transform.position;
            float spawnTimer = 0f;
            float spawnDuration = 0.5f;
            while (spawnTimer < spawnDuration)
            {
                spawnTimer += Time.deltaTime;
                currentPulpit.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(9, 1, 9), spawnTimer / spawnDuration);
                yield return new WaitForEndOfFrame();
            }
            currentPulpit.transform.localScale = new Vector3(9, 1, 9);
            // Random lifetime for the new pulpit
            float destroyTime = Random.Range(ConfigManager.doofusDiary.pulpit_data.min_pulpit_destroy_time,
                                                         ConfigManager.doofusDiary.pulpit_data.max_pulpit_destroy_time);

            currentPulpit.GetComponent<TimerUI>().timer = destroyTime;
            // Destroy the pulpit after the random time
            StartCoroutine(DestroyRoutine(currentPulpit, destroyTime));

        }
    }
    IEnumerator DestroyRoutine(GameObject pulpit, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        float destroyTimer = 0f;
        float destroyDuration = 0.5f;
        while (destroyTimer < destroyDuration)
        {
            destroyTimer += Time.deltaTime;
            pulpit.transform.localScale = Vector3.Lerp(new Vector3(9, 1, 9), Vector3.zero, destroyTimer / destroyDuration);
            yield return new WaitForEndOfFrame();
        }
        Destroy(pulpit);
    }
}
