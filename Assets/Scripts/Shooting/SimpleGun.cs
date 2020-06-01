using UnityEngine;

public class SimpleGun : IGun
{
    public void Shoot(Transform[] bulletSpawnPos)
    {
        foreach (var spawnPos in bulletSpawnPos)
        {
            var bullet = ObjectPool.Instance.PullObject("Bullet");

            bullet.transform.position = spawnPos.position;
            bullet.transform.rotation = spawnPos.rotation;
        }
    }
}