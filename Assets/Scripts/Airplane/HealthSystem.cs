using System;
using UnityEngine;
public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp;
    [SerializeField] private bool addKillToStatistic;
    public void TakeDamage(int damageTaken)
    {
        hp -= damageTaken;

        if (hp == 0)
        {
            EffectController.Instance.SpawnExplosionPrefab(transform.position);
            StatisticCollector.Instance.AddKillToStatistic();

            if (addKillToStatistic)
            {
                MissionUIController.Instance.AddKillToStatistic();
            }
            
            Destroy(gameObject);
        }

    }
}
