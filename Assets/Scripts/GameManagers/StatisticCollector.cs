using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticCollector : MonoBehaviourSingleton<StatisticCollector>
{
    private int killedEnemies;
    public int KilledEnemies => killedEnemies;

    public delegate void KillEvent();
    public static event KillEvent OnKillEvent;
    
    public void AddKillToStatistic()
    {
        killedEnemies++;
        OnKillEvent.Invoke();
    }
}
