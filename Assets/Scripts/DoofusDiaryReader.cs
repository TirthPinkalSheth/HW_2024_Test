using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;

public class DoofusDiaryReader : MonoBehaviour
{
    [System.Serializable]
    public class DoofusDiary
    {
        public PlayerData player_data;
        public PulpitData pulpit_data;
    }

    [System.Serializable]
    public class PlayerData
    {
        public float speed;
    }

    [System.Serializable]
    public class PulpitData
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }

    public class Pulpit : MonoBehaviour
    {
        public static float minPulpitDestroyTime;
        public static float maxPulpitDestroyTime;
        public static float pulpitSpawnTime;
    }

    public class Doofus : MonoBehaviour
    {
        public static float speed;
    }

    private DoofusDiary diary;

    void Start()
    {
        string json = File.ReadAllText("doofus_diary.json");
        diary = JsonUtility.FromJson<DoofusDiary>(json);

        // Set up the game values
        Doofus.speed = diary.player_data.speed;
        Pulpit.minPulpitDestroyTime = diary.pulpit_data.min_pulpit_destroy_time;
        Pulpit.maxPulpitDestroyTime = diary.pulpit_data.max_pulpit_destroy_time;
        Pulpit.pulpitSpawnTime = diary.pulpit_data.pulpit_spawn_time;
    }
}