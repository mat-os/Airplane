using DG.Tweening;
using UnityEngine;
    public class NormalEnemyState : IEnemyState
    {
        public void Execute(Airplane airplane, GameObject target)
        {
            Vector3 targetDir = target.transform.position - airplane.transform.position;
            var rotation = Quaternion.LookRotation(targetDir);
           airplane.Rb.transform.rotation = Quaternion.Slerp(airplane.Rb.transform.rotation, rotation, Time.deltaTime * 0.5f);
        }
    }
