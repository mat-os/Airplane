using UnityEngine;

public class FightingEnemyState : IEnemyState
{
    public void Execute(Airplane airplane, GameObject target)
    {
        var targetDir = target.transform.position - airplane.transform.position;

        var rotation = Quaternion.LookRotation(targetDir);

        float speedOfRotation = 0.7f;
        airplane.Rb.transform.rotation =
            Quaternion.Slerp(airplane.Rb.transform.rotation, rotation, Time.deltaTime * speedOfRotation);
        
        Vector3 forward = airplane.transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

        if (Vector3.Distance(target.transform.position, airplane.transform.position) < 500)
        {
            if (angle > -5.0F && angle < 5.0F)
            {
                airplane.Shoot();
            }
        }
    }
}