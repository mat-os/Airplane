using UnityEngine;
public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp;

    public void TakeDamage(int damageTaken)
    {
        hp -= damageTaken;

        if (hp <= 0)
        {
            EffectController.Instance.SpawnExplosionPrefab(transform.position);
            StatisticCollector.Instance.AddKillToStatistic();
            
            Destroy(gameObject);
        }
    }
}
