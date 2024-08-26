using UnityEngine;
using System.IO;
//this file is used to read conents from json file in resources folder
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
    public PlayerData player_data;//player related data is stored
    public PulpitData pulpit_data;//pulpit related data is stored
}

public class ConfigManager : MonoBehaviour
{
    public static DoofusDiary doofusDiary;

    void Awake()
    {
        LoadConfig();
    }

    void LoadConfig()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("doofus_diary");// Loads the JSON file named "doofus_diary" from the Resources folder
        doofusDiary = JsonUtility.FromJson<DoofusDiary>(jsonFile.text);
    }
}
