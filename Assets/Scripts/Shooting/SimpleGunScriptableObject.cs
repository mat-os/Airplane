using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Simpe Gun", menuName = "Simpe Gun", order = 52)]
public class SimpleGunScriptableObject : Weapon, IGun
{
    public GameObject bulletPrefab;

    public override void Shoot(Transform[] bulletSpawnPos)
    {
        foreach (var spawnPos in bulletSpawnPos)
        {
            var bullet = ObjectPool.Instance.PullObject(bulletPrefab.name);
            SoundManager.Instance.PlaySingleSfx(shootSound);

            bullet.transform.position = spawnPos.position;
            bullet.transform.rotation = spawnPos.rotation;
        }
    }
}