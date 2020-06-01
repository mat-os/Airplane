using UnityEngine;

public class FightingEnemyState : IEnemyState
{
    private float speedOfRotation = 0.8f;
    private float maxDistanceToShoot = 500f;
    private float minAngelToShoot = 6;

    public void Execute(Airplane airplane, GameObject target)
    {
        var targetDir = target.transform.position - airplane.transform.position;

        var rotation = Quaternion.LookRotation(targetDir);

        airplane.Rb.transform.rotation =
            Quaternion.Slerp(airplane.Rb.transform.rotation, rotation, Time.deltaTime * speedOfRotation);
        
        Vector3 forward = airplane.transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

        var distanceBetween = Vector3.Magnitude(targetDir);
        if (distanceBetween < maxDistanceToShoot)
        {
            if (angle > -minAngelToShoot && angle < minAngelToShoot)
            {
                airplane.Shoot();
            }
        }
    }
}