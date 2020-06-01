using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyCounterText;
    void Start()
    {
        StatisticCollector.OnKillEvent += UpdateMission;
        UpdateMission();
    }

    void UpdateMission()
    {
        enemyCounterText.text = StatisticCollector.Instance.KilledEnemies.ToString() + " out of " + EnemyController.enemyList.Count.ToString();
    }
}
