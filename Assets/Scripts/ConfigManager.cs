using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;



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

    [System.Serializable]
    public class DoofusDiary
    {
        public PlayerData player_data;
        public PulpitData pulpit_data;
    }

    public class ConfigManager : MonoBehaviour
    {
        public static DoofusDiary doofusDiary;

        void Start()
        {
            LoadConfig();
        }

        void LoadConfig()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>("doofus_diary");
            doofusDiary = JsonUtility.FromJson<DoofusDiary>(jsonFile.text);
        }
    }