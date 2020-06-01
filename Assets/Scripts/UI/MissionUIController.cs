using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionUIController : MonoBehaviourSingleton<MissionUIController>
{
    [SerializeField] private TMP_Text enemyCounterText;
    [SerializeField] private int totalEnemiesToKill = 4;
    private int missionEnemyKilled;
    void Start()
    {
        UpdateMission();
    }

    public void UpdateMission()
    {
        enemyCounterText.text = missionEnemyKilled.ToString() + " out of " + totalEnemiesToKill.ToString();
    }

    public void AddKillToStatistic()
    {
        missionEnemyKilled++;
        UpdateMission();
    }
}
