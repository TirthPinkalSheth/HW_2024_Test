using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public float timer;
    public TMP_Text timerText;

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
    }
}