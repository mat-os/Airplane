using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticCollector : MonoBehaviourSingleton<StatisticCollector>
{
    private int killedEnemies;
    public int KilledEnemies => killedEnemies;

    public void AddKillToStatistic()
    {
        killedEnemies++;
    }
}
